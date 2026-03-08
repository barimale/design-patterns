using AutoMapperGenericBidirectionalAdapter;
using AutoMapperGenericBidirectionalAdapter.Model;
using AutoMapperGenericBidirectionalAdapter.Profiles;
using UTs.Executor.BaseUT;
using Xunit.Abstractions;

namespace UTs.Executor
{
    public class AutoMapperGenericBidirectionalAdapter : PrintToConsoleUTBase
    {
        private readonly TextWriter _originalOut;
        private readonly TestOutputTextWriter _redirectWriter;

        public AutoMapperGenericBidirectionalAdapter(ITestOutputHelper output)
            : base(output)
        {
            _originalOut = Console.Out;
            _redirectWriter = new TestOutputTextWriter(output);
            Console.SetOut(_redirectWriter);
        }

        [Fact]
        public void Execute()
        {
            // given
            var automapper = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfiles(new[] { new DummyProfile() });
            }).CreateMapper();

            var adapter = new AutoMapperCustomAdapter<DTO, ViewModel>(automapper);
            var dtos = new List<DTO>
            {
                new DTO { DisplayName = "First", UpdatedAt = DateTime.UtcNow , SecondFieldName = "first"},
                new DTO { DisplayName = "Second", UpdatedAt = DateTime.UtcNow , SecondFieldName = "second"}
            };

            // when
            var vms = adapter.ToTargetCollection(dtos, (dto, vm) =>
            {
                vm.DisplayName = vm.DisplayName.ToUpper();
                vm.FieldName = dto.SecondFieldName;
            });

            var dto = adapter.ToSource(vms.FirstOrDefault(), (dto, vm) =>
            {
                dto.UpdatedAt = DateTime.UtcNow;
                dto.SecondFieldName = vm.FieldName;
            });

            var newDtos = adapter.ToSourceCollection(vms, (dto, vm) =>
            {
                dto.UpdatedAt = vm.UpdatedAt;
                dto.SecondFieldName = vm.FieldName;
            });

            // then
            Assert.Equal(dtos.Count, vms.Count());
            Assert.Equal(dtos[0].DisplayName.ToUpper(), vms.FirstOrDefault()?.DisplayName);
            Assert.Equal(dtos[0].SecondFieldName, dto.SecondFieldName);
            Assert.Equal(vms.Select(p => p.FieldName), dtos.Select(pp => pp.SecondFieldName));
            Assert.Equal(vms.Select(p => p.UpdatedAt), newDtos.Select(pp => pp.UpdatedAt));
            Output.WriteLine("Execution completed. Check test output for details.");
        }
    }
}

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
                new DTO { DisplayName = "First", UpdatedAt = DateTime.UtcNow },
                new DTO { DisplayName = "Second", UpdatedAt = DateTime.UtcNow }
            };

            // when
            var vms = adapter.ToTargetCollection(dtos, vm =>
            {
                vm.DisplayName = vm.DisplayName.ToUpper();
            });

            var dto = adapter.ToSource(vms.FirstOrDefault(), dto =>
            {
                dto.UpdatedAt = DateTime.UtcNow;
            });

            // then
            Assert.Equal(dtos.Count, vms.Count());
            Assert.Equal(dtos[0].DisplayName.ToUpper(), vms.FirstOrDefault()?.DisplayName);

            Output.WriteLine("Execution completed. Check test output for details.");
        }
    }
}

using AutoMapper;
using AutoMapperGenericBidirectionalAdapter.Model;

namespace AutoMapperGenericBidirectionalAdapter.Profiles
{
    public class DummyProfile: Profile
    {
        public DummyProfile()
        {
            CreateMap<DTO, ViewModel>();
            CreateMap<ViewModel, DTO>();
        }
    }
}

using AspDotnetCoreGenericRepository.Models;
using AspDotnetCoreGenericRepository.ViewModel;
using AutoMapper;

namespace AspDotnetCoreGenericRepository
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductVM>().ReverseMap();
        }
    }

}


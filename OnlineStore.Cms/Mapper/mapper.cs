using AutoMapper;
using OnlineStore.Cms.ViewModel;
using OnlineStore.Domain.DTO;

namespace OnlineStore.Cms.Mapper
{
    public class mapper : Profile
    {
       public mapper()
       {
            CreateMap<ProductDTO, ProductsVM>().ReverseMap();

            CreateMap<CategorieDTO, CategoriesVM>().ReverseMap();

        }
    }
}

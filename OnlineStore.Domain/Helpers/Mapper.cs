using AutoMapper;
using OnlineStore.Domain.Data;
using OnlineStore.Domain.DTO;

namespace OnlineStore.Domain.Helpers
{
    public class AppMapper : Profile
    {
       public AppMapper ()
        {
            // map product
            CreateMap<Product, ProductDTO>(); 
            CreateMap<ProductDTO, Product>();
            // map cate
            CreateMap<Categorie, CategorieDTO>();
            CreateMap<CategorieDTO, Categorie>();
            // map user
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
        }
    }
}

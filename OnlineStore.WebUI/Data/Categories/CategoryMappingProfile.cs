using AutoMapper;
using OnlineStore.WebAPI.Contracts;

namespace OnlineStore.WebUI.Data.Categories
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<CategoryContract, CategoryViewModel>().ReverseMap();
        }
    }
}
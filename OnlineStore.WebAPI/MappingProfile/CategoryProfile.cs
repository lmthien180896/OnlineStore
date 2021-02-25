using AutoMapper;
using OnlineStore.UseCase.Categories;
using OnlineStore.WebAPI.Contracts;

namespace OnlineStore.WebAPI.MappingProfile
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryDto, CategoryContract>().ReverseMap();
        }
    }
}
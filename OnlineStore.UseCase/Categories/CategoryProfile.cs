using AutoMapper;
using OnlineStore.Model;

namespace OnlineStore.UseCase.Categories
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryDto, Category>().ReverseMap();
        }
    }
}
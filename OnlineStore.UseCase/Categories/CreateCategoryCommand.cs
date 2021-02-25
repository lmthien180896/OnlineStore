using MediatR;

namespace OnlineStore.UseCase.Categories
{
    public class CreateCategoryCommand : IRequest<CategoryDto>
    {
        public string Name { get; set; }

        public string Type { get; set; }
    }
}
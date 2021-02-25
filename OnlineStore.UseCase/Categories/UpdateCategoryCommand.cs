using MediatR;

namespace OnlineStore.UseCase.Categories
{
    public class UpdateCategoryCommand : IRequest<CategoryDto>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }
    }
}
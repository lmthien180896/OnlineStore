using MediatR;

namespace OnlineStore.UseCase.Categories
{
    public class DeleteCategoryCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
}
using MediatR;
using OnlineStore.UseCase.Db;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineStore.UseCase.Categories
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, string>
    {
        private readonly OnlineStoreDbContext context;

        public DeleteCategoryCommandHandler(OnlineStoreDbContext context)
        {
            this.context = context;
        }
        public async Task<string> Handle(DeleteCategoryCommand command, CancellationToken cancellationToken)
        {
            var deletedCategory = await context.Categories.FindAsync(command.Id);

            if (deletedCategory == null)
            {
                throw new CategoryNotFoundException(command.Id);
            }

            context.Remove(deletedCategory);
            await context.SaveChangesAsync(cancellationToken);

            return deletedCategory.Name;
        }
    }
}
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Model;
using OnlineStore.UseCase.Db;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineStore.UseCase.Categories
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, CategoryDto>
    {
        private readonly OnlineStoreDbContext context;
        private readonly IMapper mapper;

        public UpdateCategoryCommandHandler(OnlineStoreDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<CategoryDto> Handle(UpdateCategoryCommand command, CancellationToken cancellationToken)
        {
            var updatedCategory = await context.Categories.FindAsync(command.Id);

            if (updatedCategory == null)
            {
                throw new CategoryNotFoundException(command.Id);
            }

            updatedCategory.Name = command.Name;
            updatedCategory.Slug = SlugGenerator.GenerateSlug(updatedCategory.Name);
            updatedCategory.Type = command.Type;

            context.Entry(updatedCategory).State = EntityState.Modified;
            try
            {
                await context.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException)
            {
                var categoryExists = await context.Categories.AnyAsync(c => c.Id == command.Id, cancellationToken);

                if (!categoryExists)
                {
                    return null;
                }
                else 
                {
                    throw;
                }
            }

            return mapper.Map<CategoryDto>(updatedCategory);
        }
    }
}
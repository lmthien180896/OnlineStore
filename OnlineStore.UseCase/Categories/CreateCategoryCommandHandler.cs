using AutoMapper;
using MediatR;
using OnlineStore.Model;
using OnlineStore.UseCase.Db;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineStore.UseCase.Categories
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryDto>
    {
        private readonly OnlineStoreDbContext context;
        private readonly IMapper mapper;        

        public CreateCategoryCommandHandler(OnlineStoreDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<CategoryDto> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                Name = command.Name,
                Slug = SlugGenerator.GenerateSlug(command.Name),
                Type = command.Type
            };

            await context.AddAsync(category);
            await context.SaveChangesAsync(cancellationToken);

            return mapper.Map<CategoryDto>(category);
        }
    }
}
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineStore.UseCase.Db;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineStore.UseCase.Categories
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, List<CategoryDto>>
    {
        private readonly OnlineStoreDbContext context;
        private readonly IMapper mapper;

        public GetCategoriesQueryHandler(OnlineStoreDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<CategoryDto>> Handle(GetCategoriesQuery query, CancellationToken cancellationToken)
        {
            var categories = context.Categories
                .AsNoTracking()
                .ToList();

            return await Task.FromResult(mapper.Map<List<CategoryDto>>(categories));
        }
    }
}
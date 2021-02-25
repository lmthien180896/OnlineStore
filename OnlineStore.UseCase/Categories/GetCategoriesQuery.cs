using MediatR;
using System.Collections.Generic;

namespace OnlineStore.UseCase.Categories
{
    public class GetCategoriesQuery : IRequest<List<CategoryDto>>
    {
    }
}
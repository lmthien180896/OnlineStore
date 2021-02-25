using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.UseCase.Categories;
using OnlineStore.WebAPI.Contracts;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineStore.WebAPI.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public CategoryController(IMediator mediatR, IMapper mapper)
        {
            this.mediator = mediatR;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories(CancellationToken cancellationToken)
        {
            var query = new GetCategoriesQuery();
            var categoryDtos = await mediator.Send(query, cancellationToken);

            return Ok(mapper.Map<List<CategoryContract>>(categoryDtos));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryContract contract, CancellationToken cancellation)
        {
            var command = new CreateCategoryCommand()
            {
                Name = contract.Name,
                Type = contract.Type
            };
            var category = await mediator.Send(command, cancellation);

            return Ok(mapper.Map<CategoryContract>(category));
        }

        [HttpPut]
        public async Task<IActionResult> Update(CategoryContract contract, CancellationToken cancellation)
        {
            var command = new UpdateCategoryCommand()
            {
                Id = contract.Id,
                Name = contract.Name,
                Type = contract.Type
            };
            var category = await mediator.Send(command, cancellation);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<CategoryContract>(category));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var command = new DeleteCategoryCommand()
            {
                Id = id
            };
            var deletedCategoryName = await mediator.Send(command, cancellationToken);

            return Ok(deletedCategoryName);
        }
    }
}
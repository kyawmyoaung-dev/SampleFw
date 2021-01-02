using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest
    {
        public string CategoryName { get; set; }

        public string Description { get; set; }

        public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand>
        {
            private readonly IApplicationDbContext _context;

            public CreateCategoryCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
            {
                Category entity = new Category()
                {
                    CategoryId = Guid.NewGuid().ToString(),
                    CategoryName = request.CategoryName,
                    Description = request.Description
                };

                await _context.Categories.AddAsync(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}

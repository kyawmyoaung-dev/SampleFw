using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Categories.Queries.GetCategoriesList
{
    public class GetCategoriesListQuery : IRequest<IEnumerable<Category>>
    {
        public class GetCategoriesListQueryHandler : IRequestHandler<GetCategoriesListQuery, IEnumerable<Category>>
        {
            private readonly IApplicationDbContext _context;

            public GetCategoriesListQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Category>> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
            {
                var categories = await _context.Categories.ToListAsync();

                if (categories == null)
                {
                    return null;
                }

                return categories;
            }
        }

    }
}

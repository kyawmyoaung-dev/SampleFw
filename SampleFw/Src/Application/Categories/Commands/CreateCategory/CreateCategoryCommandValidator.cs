using Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        private readonly IApplicationDbContext _dbContext;


        public CreateCategoryCommandValidator(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(v => v.CategoryName)
                .NotEmpty().WithMessage("Category Name is required.")
                .MaximumLength(200).WithMessage("Category Name must not exceed 200 characters.")
                .MustAsync(BeUniqueName).WithMessage("The specified title already exists.");
        }

        public async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken)
        {
            return await _dbContext.Categories
                .AllAsync(l => l.CategoryName != name);
        }
    }
}

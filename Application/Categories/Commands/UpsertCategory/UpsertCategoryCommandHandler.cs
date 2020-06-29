using MediatR;
using SimpleCMS.Application.Common.Exceptions;
using SimpleCMS.Application.Common.Interfaces;
using SimpleCMS.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleCMS.Application.Categories.Commands.UpsertCategory
{
    public class UpsertCategoryCommandHandler : IRequestHandler<UpsertCategoryCommand, int>
    {
        private readonly ISimpleDbContext _context;

        public UpsertCategoryCommandHandler(ISimpleDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpsertCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category;

            if (request.Id.HasValue)
            {
                category = await _context.Categories.FindAsync(request.Id.Value);

                if (category == null) throw new NotFoundException(nameof(Category), request.Id);
            }
            else
            {
                category = new Category();

                _context.Categories.Add(category);
            }

            category.Name = request.Name;
            category.Description = request.Description;

            await _context.SaveChangesAsync(cancellationToken);

            return category.CategoryId;
        }
    }
}

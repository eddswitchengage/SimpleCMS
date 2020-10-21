using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleCMS.Application.Categories.Queries.Common;
using SimpleCMS.Application.Common.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleCMS.Application.Categories.Queries.GetCategoryDetail
{
    public class GetCategoryDetailQueryHandler : IRequestHandler<GetCategoryDetailQuery, CategoryDetailVM>
    {
        private readonly ISimpleDbContext _context;
        private readonly IMapper _mapper;

        public GetCategoryDetailQueryHandler(ISimpleDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CategoryDetailVM> Handle(GetCategoryDetailQuery request, CancellationToken cancellationToken)
        {
            var viewModel = await _context.Categories
                .Where(c => c.CategoryId == request.Id)
                .ProjectTo<CategoryDetailVM>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(cancellationToken);

            return viewModel;
        }
    }
}

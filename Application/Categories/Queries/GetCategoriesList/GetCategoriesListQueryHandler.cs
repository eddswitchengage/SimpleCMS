using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleCMS.Application.Categories.Queries.Common;
using SimpleCMS.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleCMS.Application.Categories.Queries.GetCategoriesList
{
    public class GetCategoriesListQueryHandler : IRequestHandler<GetCategoriesListQuery, CategoriesListVM>
    {
        private readonly ISimpleDbContext _context;
        private readonly IMapper _mapper;

        public GetCategoriesListQueryHandler(ISimpleDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CategoriesListVM> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
        {
            var categories = await _context.Categories
                .ProjectTo<CategoryDetailVM>(_mapper.ConfigurationProvider)
                .ToListAsync();

            var viewModel = new CategoriesListVM()
            {
                Categories = categories,
                Count = categories.Count
            };

            return viewModel;
        }
    }
}

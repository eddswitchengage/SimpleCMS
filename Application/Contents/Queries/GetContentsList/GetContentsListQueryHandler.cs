using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleCMS.Application.Common.Interfaces;
using SimpleCMS.Application.Contents.Queries.Common;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleCMS.Application.Contents.Queries.GetContentsList
{
    public class GetContentsListQueryHandler : IRequestHandler<GetContentsListQuery, ContentsListVM>
    {
        private readonly ISimpleDbContext _context;
        private readonly IMapper _mapper;

        public GetContentsListQueryHandler(ISimpleDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ContentsListVM> Handle(GetContentsListQuery request, CancellationToken cancellationToken)
        {
            var contents = await _context.Contents.
                ProjectTo<ContentDetailVM>(_mapper.ConfigurationProvider).
                ToListAsync(cancellationToken);

            var viewModel = new ContentsListVM()
            {
                Contents = contents,
                Count = contents.Count
            };

            return viewModel;
        }
    }
}

using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleCMS.Application.Common.Interfaces;
using SimpleCMS.Application.Contents.Queries.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleCMS.Application.Contents.Queries.GetContentDetail
{
    public class GetContentDetailQueryHandler : IRequestHandler<GetContentDetailQuery, ContentDetailVM>
    {
        private ISimpleDbContext _context;
        private IMapper _mapper;

        public GetContentDetailQueryHandler(ISimpleDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ContentDetailVM> Handle(GetContentDetailQuery request, CancellationToken cancellationToken)
        {
            var viewModel = await _context.Contents
                .Where(c => c.ContentId == request.Id)
                .ProjectTo<ContentDetailVM>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(cancellationToken);

            return viewModel;
        }
    }
}

using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleCMS.Application.Common.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleCMS.Application.Topics.Queries.GetTopicDetail
{
    public class GetTopicDetailQueryHandler : IRequestHandler<GetTopicDetailQuery, TopicDetailVM>
    {
        private readonly ISimpleDbContext _context;
        private readonly IMapper _mapper;

        public GetTopicDetailQueryHandler(ISimpleDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TopicDetailVM> Handle(GetTopicDetailQuery request, CancellationToken cancellationToken)
        {
            var viewModel = await _context.Topics
                .Where(t => t.TopicId == request.Id)
                .ProjectTo<TopicDetailVM>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(cancellationToken);

            return viewModel;
        }
    }
}

using AutoMapper.QueryableExtensions;
using MediatR;
using SimpleCMS.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace SimpleCMS.Application.Topics.Queries.GetTopicsList
{
    public class GetTopicsListQueryHandler : IRequestHandler<GetTopicsListQuery, TopicsListVM>
    {
        private readonly ISimpleDbContext _context;
        private readonly IMapper _mapper;

        public GetTopicsListQueryHandler(ISimpleDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TopicsListVM> Handle(GetTopicsListQuery request, CancellationToken cancellationToken)
        {
            var topics = await _context.Topics
                .ProjectTo<TopicDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();

            var viewModel = new TopicsListVM()
            {
                Topics = topics,
                Count = topics.Count
            };

            return viewModel;
        }
    }
}

using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleCMS.Application.Common.Interfaces;
using SimpleCMS.Application.Topics.Queries.Common;
using System.Threading;
using System.Threading.Tasks;

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
                .ProjectTo<TopicDetailVM>(_mapper.ConfigurationProvider)
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

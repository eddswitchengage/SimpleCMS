using AutoMapper;
using AutoMapper.QueryableExtensions;
using LinqKit;
using MediatR;
using SimpleCMS.Application.Common.Interfaces;
using SimpleCMS.Application.Common.Collections;
using SimpleCMS.Application.Contents.Queries.Common;
using SimpleCMS.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Data.Entity;

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
            var predicate = PredicateBuilder.New<Content>(true);

            if (request.TopicId != 0) predicate = predicate.And(c => c.TopicId == request.TopicId);
            if (request.CategoryId != 0) predicate = predicate.And(c => c.Topic.CategoryId == request.CategoryId);
            if (request.CreatedAfter != null) predicate = predicate.And(c => c.Created >= request.CreatedAfter.Value);
            if (request.ModifiedAfter != null) predicate = predicate.And(c => c.LastModified >= request.ModifiedAfter.Value);

            var contents = _context.Contents.Where(predicate).AsNoTracking().ProjectTo<ContentDetailVM>(_mapper.ConfigurationProvider);

            var paginatedContents = await PaginatedList<ContentDetailVM>.CreateAsync(contents, request.PageIndex, request.PageSize);

            var viewModel = new ContentsListVM()
            {
                Contents = paginatedContents,
                Count = paginatedContents.Count()
            };

            return viewModel;
        }
    }
}

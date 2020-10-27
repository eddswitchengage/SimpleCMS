using MediatR;
using System;

namespace SimpleCMS.Application.Contents.Queries.GetContentsList
{
    public class GetContentsListQuery : IRequest<ContentsListVM>
    {
        public GetContentsListQuery()
        {
            PageIndex = 1;
            PageSize = 10;
        }

        public string SearchTerm { get; set; }

        public DateTime? CreatedAfter { get; set; }
        public DateTime? ModifiedAfter { get; set; }
        public int TopicId { get; set; }
        public int CategoryId { get; set; }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}

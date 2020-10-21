using MediatR;
using SimpleCMS.Application.Topics.Queries.Common;

namespace SimpleCMS.Application.Topics.Queries.GetTopicDetail
{
    public class GetTopicDetailQuery : IRequest<TopicDetailVM>
    {
        public int Id { get; set; }
    }
}

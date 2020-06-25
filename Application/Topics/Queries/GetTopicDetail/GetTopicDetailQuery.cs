using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCMS.Application.Topics.Queries.GetTopicDetail
{
    public class GetTopicDetailQuery : IRequest<TopicDetailVM>
    {
        public int Id { get; set; }
    }
}

using SimpleCMS.Application.Topics.Queries.Common;
using System.Collections.Generic;

namespace SimpleCMS.Application.Topics.Queries.GetTopicsList
{
    public class TopicsListVM
    {
        public IList<TopicDetailVM> Topics { get; set; }
        public int Count { get; set; }
    }
}

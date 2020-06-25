using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCMS.Application.Topics.Queries.GetTopicsList
{
    public class TopicsListVM
    {
        public IList<TopicDTO> Topics { get; set; }
        public int Count { get; set; }
    }
}

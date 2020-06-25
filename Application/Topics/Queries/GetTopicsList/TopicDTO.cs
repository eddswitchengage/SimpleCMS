using AutoMapper;
using SimpleCMS.Application.Common.Mappings;
using SimpleCMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCMS.Application.Topics.Queries.GetTopicsList
{
    public class TopicDTO : IMapFrom<Topic>
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile) =>
            profile.CreateMap<Topic, TopicDTO>()
            .ForMember(d => d.Id, opt => opt.MapFrom(e => e.TopicId));
    }
}

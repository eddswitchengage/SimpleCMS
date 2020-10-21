using AutoMapper;
using SimpleCMS.Application.Common.Mappings;
using SimpleCMS.Application.Topics.Queries.GetTopicDetail;
using SimpleCMS.Domain.Entities;
using System.Collections.Generic;

namespace SimpleCMS.Application.Topics.Queries.Common
{
    public class TopicDetailVM : IMapFrom<Topic>
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile) =>
            profile.CreateMap<Topic, TopicDetailVM>()
            .ForMember(v => v.Id, opt => opt.MapFrom(e => e.TopicId));
    }
}

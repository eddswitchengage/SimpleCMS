using AutoMapper;
using SimpleCMS.Application.Common.Mappings;
using SimpleCMS.Domain.Entities;

namespace SimpleCMS.Application.Topics.Queries.GetTopicDetail
{
    public class TopicContentDTO : IMapFrom<Content>
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile) =>
            profile.CreateMap<Content, TopicContentDTO>()
            .ForMember(d => d.Id, opt => opt.MapFrom(e => e.ContentId));
    }
}

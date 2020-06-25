using AutoMapper;
using SimpleCMS.Application.Common.Mappings;
using SimpleCMS.Domain.Entities;

namespace SimpleCMS.Application.Contents.Queries.GetContentsList
{
    public class ContentDTO : IMapFrom<Content>
    {
        public int Id { get; set; }

        public int TopicId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile) =>
            profile.CreateMap<Content, ContentDTO>()
            .ForMember(d => d.Id, opt => opt.MapFrom(e => e.ContentId));
    }
}

using AutoMapper;
using SimpleCMS.Application.Common.Mappings;
using SimpleCMS.Domain.Entities;

namespace SimpleCMS.Application.Contents.Queries.GetContentDetail
{
    public class ContentDetailVM : IMapFrom<Content>
    {
        public int Id { get; set; }

        public int TopicId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile) =>
            profile.CreateMap<Content, ContentDetailVM>()
            .ForMember(v => v.Id, opt => opt.MapFrom(e => e.ContentId));
    }
}

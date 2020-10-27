using AutoMapper;
using SimpleCMS.Application.Common.Mappings;
using SimpleCMS.Domain.Entities;
using System;

namespace SimpleCMS.Application.Contents.Queries.Common
{
    public class ContentDetailVM : IMapFrom<Content>
    {
        public int Id { get; set; }

        public int TopicId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string HTMLBody { get; set; }
        public string Tags { get; set; }

        public DateTime LastModified { get; set; }
        public DateTime Created { get; set; }

        public void Mapping(Profile profile) =>
            profile.CreateMap<Content, ContentDetailVM>()
            .ForMember(v => v.Id, opt => opt.MapFrom(e => e.ContentId));
    }
}

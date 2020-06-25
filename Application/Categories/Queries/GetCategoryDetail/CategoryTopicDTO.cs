using AutoMapper;
using SimpleCMS.Application.Common.Mappings;
using SimpleCMS.Domain.Entities;

namespace SimpleCMS.Application.Categories.Queries.GetCategoryDetail
{
    public class CategoryTopicDTO : IMapFrom<Topic>
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }


        public void Mapping(Profile profile) =>
            profile.CreateMap<Topic, CategoryTopicDTO>()
            .ForMember(d => d.Id, opt => opt.MapFrom(e => e.TopicId));
    }
}

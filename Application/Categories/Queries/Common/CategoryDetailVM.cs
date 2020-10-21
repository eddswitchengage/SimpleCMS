using AutoMapper;
using SimpleCMS.Application.Categories.Queries.GetCategoryDetail;
using SimpleCMS.Application.Common.Mappings;
using SimpleCMS.Domain.Entities;
using System.Collections.Generic;

namespace SimpleCMS.Application.Categories.Queries.Common
{
    public class CategoryDetailVM : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public virtual List<CategoryTopicVM> Topics { get; set; }

        public void Mapping(Profile profile) =>
            profile.CreateMap<Category, CategoryDetailVM>()
            .ForMember(v => v.Id, opt => opt.MapFrom(e => e.CategoryId))
            .ForMember(v => v.Topics, opt => opt.MapFrom(e => e.Topics));
    }
}

using AutoMapper;
using SimpleCMS.Application.Common.Mappings;
using SimpleCMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCMS.Application.Categories.Queries.GetCategoryDetail
{
    public class CategoryDetailVM : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual List<CategoryTopicDTO> Topics { get; set; }

        public void Mapping(Profile profile) =>
            profile.CreateMap<Category, CategoryDetailVM>()
            .ForMember(v => v.Id, opt => opt.MapFrom(e => e.CategoryId))
            .ForMember(v => v.Topics, opt => opt.MapFrom(e => e.Topics));
    }
}

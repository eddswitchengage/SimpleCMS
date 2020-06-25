﻿using AutoMapper;
using SimpleCMS.Application.Common.Mappings;
using SimpleCMS.Domain.Entities;

namespace SimpleCMS.Application.Categories.Queries.GetCategoriesList
{
    public class CategoryDTO : IMapFrom<Category>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile) =>
            profile.CreateMap<Category, CategoryDTO>()
            .ForMember(d => d.Id, opt => opt.MapFrom(e => e.CategoryId));
    }
}

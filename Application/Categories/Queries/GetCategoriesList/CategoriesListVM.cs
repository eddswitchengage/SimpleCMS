using SimpleCMS.Application.Categories.Queries.Common;
using System.Collections.Generic;

namespace SimpleCMS.Application.Categories.Queries.GetCategoriesList
{
    public class CategoriesListVM
    {
        public IList<CategoryDetailVM> Categories { get; set; }
        public int Count { get; set; }
    }
}

using System.Collections.Generic;

namespace SimpleCMS.Application.Categories.Queries.GetCategoriesList
{
    public class CategoriesListVM
    {
        public IList<CategoryDTO> Categories { get; set; }
        public int Count { get; set; }
    }
}

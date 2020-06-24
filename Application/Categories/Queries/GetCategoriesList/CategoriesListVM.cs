using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCMS.Application.Categories.Queries.GetCategoriesList
{
    public class CategoriesListVM
    {
        public IList<CategoryDTO> Categories { get; set; }
        public int Count { get; set; }
    }
}

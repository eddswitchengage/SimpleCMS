using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCMS.Domain.Entities
{
    public class Category
    {
        public Category()
        {
            Topics = new HashSet<Topic>();
        }

        public int CategoryId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Topic> Topics { get; private set; }
    }
}

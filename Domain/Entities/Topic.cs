﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCMS.Domain.Entities
{
    public class Topic
    {
        public Topic()
        {
            Contents = new HashSet<Content>();
        }

        public int TopicId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Content> Contents { get; private set; }
    }
}

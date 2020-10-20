using SimpleCMS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCMS.Domain.Entities
{
    public class Content : AuditableEntity
    {
        public int ContentId { get; set; }

        public int TopicId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public string HTMLBody { get; set; }
    }
}

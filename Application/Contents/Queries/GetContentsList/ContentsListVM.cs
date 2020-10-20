using SimpleCMS.Application.Contents.Queries.Common;
using System.Collections.Generic;

namespace SimpleCMS.Application.Contents.Queries.GetContentsList
{
    public class ContentsListVM
    {
        public IList<ContentDetailVM> Contents { get; set; }
        public int Count { get; set; }
    }
}

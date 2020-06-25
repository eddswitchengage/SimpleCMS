using System.Collections.Generic;

namespace SimpleCMS.Application.Contents.Queries.GetContentsList
{
    public class ContentsListVM
    {
        public IList<ContentDTO> Contents { get; set; }
        public int Count { get; set; }
    }
}

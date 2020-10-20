using MediatR;
using SimpleCMS.Application.Contents.Queries.Common;

namespace SimpleCMS.Application.Contents.Queries.GetContentDetail
{
    public class GetContentDetailQuery : IRequest<ContentDetailVM>
    {
        public int Id { get; set; }
    }
}

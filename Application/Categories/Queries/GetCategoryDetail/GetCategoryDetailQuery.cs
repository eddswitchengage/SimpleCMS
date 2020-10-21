using MediatR;
using SimpleCMS.Application.Categories.Queries.Common;

namespace SimpleCMS.Application.Categories.Queries.GetCategoryDetail
{
    public class GetCategoryDetailQuery : IRequest<CategoryDetailVM>
    {
        public int Id { get; set; }
    }
}

using MediatR;
using System.Runtime.InteropServices;

namespace SimpleCMS.Application.Categories.Queries.GetCategoryDetail
{
    public class GetCategoryDetailQuery : IRequest<CategoryDetailVM>
    {
        public int Id { get; set; }
    }
}

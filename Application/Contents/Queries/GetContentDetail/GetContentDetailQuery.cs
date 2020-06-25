using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCMS.Application.Contents.Queries.GetContentDetail
{
    public class GetContentDetailQuery : IRequest<ContentDetailVM>
    {
        public int Id { get; set; }
    }
}

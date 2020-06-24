using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCMS.Application.Topics.Commands.DeleteTopic
{
    public class DeleteTopicCommand : IRequest
    {
        public int Id { get; set; }
    }
}

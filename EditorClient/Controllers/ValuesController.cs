using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleCMS.Application.Common.Interfaces;

namespace SimpleCMS.EditorClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ISimpleDbContext _context;

        public ValuesController(ISimpleDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Get()
        {
            return Ok();
        }
    }
}

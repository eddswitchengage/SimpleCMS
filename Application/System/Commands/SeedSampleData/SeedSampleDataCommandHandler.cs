using MediatR;
using SimpleCMS.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleCMS.Application.System.Commands.SeedSampleData
{
    public class SeedSampleDataCommandHandler : IRequestHandler<SeedSampleDataCommand>
    {
        private readonly ISimpleDbContext _context;

        public SeedSampleDataCommandHandler(ISimpleDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(SeedSampleDataCommand request, CancellationToken cancellationToken)
        {
            var dbSeeder = new SampleDataSeeder(_context);

            await dbSeeder.SeedAllAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

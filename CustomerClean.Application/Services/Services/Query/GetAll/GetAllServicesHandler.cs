using CustomerClean.Domain.Models;
using CustomerClean.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CustomerClean.Application.Services.Services.Query.GetAll
{
    public class GetAllServicesHandler : IRequestHandler<GetAllServicesQuery, List<Services_tbl>>
    {
        private readonly GeneralContext _context;

        public GetAllServicesHandler(GeneralContext context)
        {
            _context = context;
        }
        public async Task<List<Services_tbl>> Handle(GetAllServicesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Services_tbl.ToListAsync();
        }
    }
}
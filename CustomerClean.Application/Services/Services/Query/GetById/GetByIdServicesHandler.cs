using CustomerClean.Application.Services.Services.Query.GetAll;
using CustomerClean.Domain.Models;
using CustomerClean.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CustomerClean.Application.Services.Services.Query.GetById
{
    public class GetIdHandler : IRequestHandler<GetIdQuery, Services_tbl>
    {
        private readonly GeneralContext _context;

        public GetIdHandler(GeneralContext context)
        {
            _context = context;
        }
        public async Task<Services_tbl> Handle(GetIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Services_tbl.Where(i=>i.id==request.Id).SingleOrDefaultAsync();
        }
    }
}
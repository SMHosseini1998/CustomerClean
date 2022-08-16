using CustomerClean.Domain.Models;
using CustomerClean.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CustomerClean.Application.Services.Citys.Query.GetAll
{
    public class GetAllCityHandler : IRequestHandler<GetAllCityQuery, List<city>>
    {
        private readonly GeneralContext _context;

        public GetAllCityHandler(GeneralContext context)
        {
            _context = context;
        }
        public async Task<List<city>> Handle(GetAllCityQuery request, CancellationToken cancellationToken)
        {
            return await _context.city.Where(i=>i.province_id==request.Id).ToListAsync();
        }
    }
}

using CustomerClean.Domain.Models;
using CustomerClean.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CustomerClean.Application.Services.Province.Query.GetAll
{
    public class GetAllProvinceHandler : IRequestHandler<GetAllProvinceQuery, List<province>>
    {
        private readonly GeneralContext _context;

        public GetAllProvinceHandler(GeneralContext context)
        {
            _context = context;
        }
        public async Task<List<province>> Handle(GetAllProvinceQuery request, CancellationToken cancellationToken)
        {
            return await _context.province.ToListAsync();
        }
    }
}

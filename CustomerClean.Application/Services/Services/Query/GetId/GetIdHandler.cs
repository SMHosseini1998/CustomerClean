using CustomerClean.Application.Services.Services.Query.GetAll;
using CustomerClean.Domain.Models;
using CustomerClean.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CustomerClean.Application.Services.Services.Query.GetId
{
    public class GetIdHandler : IRequestHandler<GetIdQuery, string>
    {
        private readonly GeneralContext _context;

        public GetIdHandler(GeneralContext context)
        {
            _context = context;
        }
        public async Task<string> Handle(GetIdQuery request, CancellationToken cancellationToken)
        {
            int Customer=  await _context.Main_Form_tbl.CountAsync();
            return (Customer+1).ToString();
        }
    }
}
using CustomerClean.Application.Services.Customer.Query.GetAll;
using CustomerClean.Domain.Models;
using CustomerClean.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerClean.Application.Services.Customer.Query.GetById
{
    public class GeCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, Main_Form_tbl>
    {
        private readonly GeneralContext _context;

        public GeCustomerByIdHandler(GeneralContext context)
        {
            _context = context;
        }
        public async Task<Main_Form_tbl> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Main_Form_tbl.Where(i=>i.id==request.Id).Include(o=>o.Services_tbl).Include(i=>i.city).ThenInclude(i=>i.Province).SingleOrDefaultAsync();
        }
    }
}

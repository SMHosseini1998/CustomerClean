using AutoMapper;
using CustomerClean.Application.Common.UploadFile;
using CustomerClean.Application.Services.Customer.Command.CreateCustomer;
using CustomerClean.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerClean.Application.Services.Customer.Command.DeleteCustomer
{
    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand, bool>
    {

        private readonly GeneralContext _context;
        private readonly IMapper _mapper;

        public DeleteCustomerHandler(GeneralContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var Customer = await _context.Main_Form_tbl.Where(i => i.id == request.Id).SingleOrDefaultAsync();
            if (Customer == null)
                return false;
            _context.Main_Form_tbl.Remove(Customer);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

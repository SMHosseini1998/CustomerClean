using AutoMapper;
using CustomerClean.Application.Common.UploadFile;
using CustomerClean.Application.Services.Customer.Command.CreateCustomer;
using CustomerClean.Infrastructure.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerClean.Application.Services.Services.Command.CreateServices
{
    public class CreateServicesHandler : IRequestHandler<CreateServicesCommand, bool>
    {

        private readonly GeneralContext _context;
        private readonly IMapper _mapper;
      
        public CreateServicesHandler(GeneralContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> Handle(CreateServicesCommand request, CancellationToken cancellationToken)
        {
            var Services = _mapper.Map<Domain.Models.Services_tbl>(request);
            Services.IsActive = true;
            await _context.Services_tbl.AddAsync(Services);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

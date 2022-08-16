using AutoMapper;
using CustomerClean.Application.Common.UploadFile;
using CustomerClean.Application.Services.Customer.Command.EditeCustomer;
using CustomerClean.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CustomerClean.Application.Services.Services.Command.EditeServices
{
    public class EditeServicesHandler : IRequestHandler<EditeServicesCommand, bool>
    {

        private readonly GeneralContext _context;
        private readonly IMapper _mapper;
     
        public EditeServicesHandler(GeneralContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> Handle(EditeServicesCommand request, CancellationToken cancellationToken)
        {
            var Services = _mapper.Map<Domain.Models.Services_tbl>(request);
            Services.IsDeleted = true;
            var Customer = await _context.Main_Form_tbl.Where(i => i.Services_Id == Services.id).FirstOrDefaultAsync();
            if (Customer != null)
                return false;
            _context.Services_tbl.Update(Services);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

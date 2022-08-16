using AutoMapper;
using CustomerClean.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CustomerClean.Application.Services.Services.Command.DeleteServices
{
    public class DeleteServicesHandler : IRequestHandler<DeleteServicesCommand, bool>
    {

        private readonly GeneralContext _context;
        private readonly IMapper _mapper;

        public DeleteServicesHandler(GeneralContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> Handle(DeleteServicesCommand request, CancellationToken cancellationToken)
        {
            var Services = await _context.Services_tbl.Where(i => i.id == request.Id).SingleOrDefaultAsync();
            if (Services == null)
                return false;
            var Customer = await _context.Main_Form_tbl.Where(i => i.Services_Id == Services.id).FirstOrDefaultAsync();
            if (Customer != null)
                return false;
            _context.Services_tbl.Remove(Services);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

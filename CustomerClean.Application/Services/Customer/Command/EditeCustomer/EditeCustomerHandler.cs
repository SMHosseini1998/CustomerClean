using AutoMapper;
using CustomerClean.Application.Common.UploadFile;
using CustomerClean.Infrastructure.Context;
using MediatR;

namespace CustomerClean.Application.Services.Customer.Command.EditeCustomer
{
    public class EditeCustomerHandler : IRequestHandler<EditeCustomerCommand, bool>
    {

        private readonly GeneralContext _context;
        private readonly IMapper _mapper;
        private readonly IUploadService _UploadService;
        public EditeCustomerHandler(GeneralContext context, IMapper mapper, IUploadService UploadService)
        {
            _context = context;
            _UploadService = UploadService;
            _mapper = mapper;
        }
        public async Task<bool> Handle(EditeCustomerCommand request, CancellationToken cancellationToken)
        {
            var Customer = _mapper.Map<Domain.Models.Main_Form_tbl>(request);
            if(request.Meli_Image_Name == null)
                Customer.Meli_Image_Name = await _UploadService.UploadFile("Customer", request.MeliImage_Name);
            if (request.Guarantee_Image_Name == null)
                Customer.Guarantee_Image_Name = await _UploadService.UploadFile("Customer", request.GuaranteeImage_Name);
            _context.Main_Form_tbl.Update(Customer);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

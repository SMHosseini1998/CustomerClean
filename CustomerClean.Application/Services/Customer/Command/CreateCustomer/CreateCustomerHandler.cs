using AutoMapper;
using CustomerClean.Application.Common.UploadFile;
using CustomerClean.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CustomerClean.Application.Services.Customer.Command.CreateCustomer
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, bool>
    {

        private readonly GeneralContext _context;
        private readonly IMapper _mapper;
        private readonly IUploadService _UploadService;
        public CreateCustomerHandler(GeneralContext context, IMapper mapper, IUploadService UploadService)
        {
            _context = context;
            _UploadService = UploadService;
            _mapper = mapper;
        }
        public async Task<bool> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var Customer = _mapper.Map<Domain.Models.Main_Form_tbl>(request);
            var FindServices_IdCustomer = _context.Main_Form_tbl.Where(i => i.Sys_Id == request.Sys_Id).SingleOrDefault();
            if (FindServices_IdCustomer != null)
            {
                int Size = await _context.Main_Form_tbl.CountAsync();
                Customer.Sys_Id = "LS-30-" + (Size + 1);
            }
            Customer.Meli_Image_Name = await _UploadService.UploadFile("Customer", request.MeliImage_Name);
            Customer.Guarantee_Image_Name = await _UploadService.UploadFile("Customer", request.GuaranteeImage_Name);
            await _context.Main_Form_tbl.AddAsync(Customer);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

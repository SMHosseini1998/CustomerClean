using AutoMapper;
using CustomerClean.Application.Services.Customer.Command.CreateCustomer;
using CustomerClean.Application.Services.Customer.Command.EditeCustomer;
using CustomerClean.Application.Services.Services.Command.CreateServices;
using CustomerClean.Application.Services.Services.Command.EditeServices;

namespace CustomerClean.Application.Common.AutoMapper
{
    public sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateCustomerMap();
            CreateServicesMap();
        }
        private void CreateCustomerMap()
        {
            CreateMap<Domain.Models.Main_Form_tbl, CreateCustomerCommand>().ReverseMap();
            CreateMap<Domain.Models.Main_Form_tbl, EditeCustomerCommand>().ReverseMap();
        }
        private void CreateServicesMap()
        {
            CreateMap<Domain.Models.Services_tbl, CreateServicesCommand>().ReverseMap();
            CreateMap<Domain.Models.Services_tbl, EditeServicesCommand>().ReverseMap();
        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Http;

namespace CustomerClean.Application.Services.Customer.Command.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<bool>
    {
        public string? FName { get; set; }
        public string? Lname { get; set; }
        public string? Sys_Id { get; set; }
        public string? Mobile { get; set; }
        public int State_Id { get; set; }
        public int City_Id { get; set; }
        public string? Address { get; set; }
        public int Services_Id { get; set; }
        public string? Gride_id { get; set; }
        public IFormFile MeliImage_Name { get; set; }
        public IFormFile GuaranteeImage_Name { get; set; }
    }
}

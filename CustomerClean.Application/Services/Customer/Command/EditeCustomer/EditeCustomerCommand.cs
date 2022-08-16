using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerClean.Application.Services.Customer.Command.EditeCustomer
{
    public class EditeCustomerCommand : IRequest<bool>
    {
        public int id { get; set; }
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
        public string? Meli_Image_Name { get; set; }
        public string? Guarantee_Image_Name { get; set; }


    }
}

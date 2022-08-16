using CustomerClean.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerClean.Application.Services.Customer.Query.GetById
{
    public class GetCustomerByIdQuery : IRequest<Main_Form_tbl>
    {
        public int Id { get; set; }
    }
}

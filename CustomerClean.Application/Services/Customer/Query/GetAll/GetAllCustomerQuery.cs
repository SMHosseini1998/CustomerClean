using CustomerClean.Application.Common.Helper.Pagination;
using CustomerClean.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CustomerClean.Application.Services.Customer.Query.GetAll
{
    public class GetAllCustomerQuery : PagingOptions, IRequest<PagedList<Main_Form_tbl>>
    {

    }
}
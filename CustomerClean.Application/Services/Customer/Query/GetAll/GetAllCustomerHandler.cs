using AutoMapper;
using CustomerClean.Application.Common.Helper.Pagination;
using CustomerClean.Domain.Models;
using CustomerClean.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CustomerClean.Application.Services.Customer.Query.GetAll
{
    public class GetAllCustomerHandler :
        PagingService<Domain.Models.Main_Form_tbl>,
        IRequestHandler<GetAllCustomerQuery, PagedList<Main_Form_tbl>>
    {
        private readonly GeneralContext _context;
        private IMapper Mapper { get; }
        public GetAllCustomerHandler(IMapper mapper, GeneralContext context)
        {

            Mapper = mapper;
            _context = context;
        }
        public async Task<PagedList<Main_Form_tbl>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
        {
            
            var Customers = _context.Main_Form_tbl.AsQueryable();

            if (!string.IsNullOrEmpty(request.Search))
                Customers = Customers
                    .Where(o => o.FName.Contains(request.Search) ||
                                o.Lname.Contains(request.Search) ||
                                o.Mobile.Contains(request.Search));

            Customers = Customers.OrderByDescending(o => o.CreateDate);
            var CustomersList =
                await GetPagedAsync(request.Page,
                    request.Limit, Customers.Include(i=>i.city).ThenInclude(i=>i.Province), cancellationToken);

            return CustomersList.MapTo<Main_Form_tbl>(Mapper);
        }
    }
}

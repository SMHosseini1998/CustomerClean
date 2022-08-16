using CustomerClean.Domain.Models;
using MediatR;


namespace CustomerClean.Application.Services.Services.Query.GetAll
{
    public class GetAllServicesQuery : IRequest<List<Services_tbl>>
    {
    }
}


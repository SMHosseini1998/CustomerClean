using CustomerClean.Domain.Models;
using MediatR;

namespace CustomerClean.Application.Services.Citys.Query.GetAll
{
    public class GetAllCityQuery : IRequest<List<city>>
    {
        public int Id { get; set; }
    }
}

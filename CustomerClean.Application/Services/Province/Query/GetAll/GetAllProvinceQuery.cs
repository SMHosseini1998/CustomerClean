using CustomerClean.Domain.Models;
using MediatR;

namespace CustomerClean.Application.Services.Province.Query.GetAll
{
    public class GetAllProvinceQuery : IRequest<List<province>>
    {
    }
}

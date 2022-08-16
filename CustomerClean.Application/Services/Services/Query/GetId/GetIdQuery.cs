using CustomerClean.Domain.Models;
using MediatR;

namespace CustomerClean.Application.Services.Services.Query.GetId
{
    public class GetIdQuery : IRequest<string>
    {
        public int Id { get; set; }
    }
}


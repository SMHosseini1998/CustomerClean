using CustomerClean.Domain.Models;
using MediatR;

namespace CustomerClean.Application.Services.Services.Query.GetById
{
    public class GetIdQuery : IRequest<Services_tbl>
    {
        public int Id { get; set; }
    }
}


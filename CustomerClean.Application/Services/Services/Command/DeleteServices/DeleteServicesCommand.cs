using MediatR;

namespace CustomerClean.Application.Services.Services.Command.DeleteServices
{
    public class DeleteServicesCommand : IRequest<bool>
    {
        public int Id { get; set; }

    }
}

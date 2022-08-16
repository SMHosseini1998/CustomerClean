using MediatR;

namespace CustomerClean.Application.Services.Services.Command.CreateServices
{
    public class CreateServicesCommand : IRequest<bool>
    {
        public string Service_Name { get; set; }
    }
}

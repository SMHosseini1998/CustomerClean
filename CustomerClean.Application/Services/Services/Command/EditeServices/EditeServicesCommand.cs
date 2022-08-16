using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerClean.Application.Services.Services.Command.EditeServices
{
    public class EditeServicesCommand : IRequest<bool>
    {
        public int id { get; set; }
        public string Service_Name { get; set; }
    }
}

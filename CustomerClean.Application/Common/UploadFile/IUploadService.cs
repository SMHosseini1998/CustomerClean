using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerClean.Application.Common.UploadFile
{
    public interface IUploadService
    {
        Task <string> UploadFile(string Addres, IFormFile Files);
    }
}

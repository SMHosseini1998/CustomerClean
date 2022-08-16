using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CustomerClean.Application.Common.UploadFile
{
    public class UploadService : IUploadService
    {
        private readonly IHostingEnvironment env;
        public UploadService(IHostingEnvironment env)
        {
            this.env = env;
        }
        public async Task<string> UploadFile(string Addres, IFormFile? Files)
        {
            var uploadDirecotroy = Addres;
            var uploadPath = Path.Combine(env.WebRootPath, uploadDirecotroy);
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }


            if (Files!=null)
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(Files.FileName);
                var filePath = Path.Combine(uploadPath, fileName);


                using (var strem = File.Create(filePath))
                {
                    await Files.CopyToAsync(strem);
                }
                return fileName;
            }
            return "";
        }
    }
}

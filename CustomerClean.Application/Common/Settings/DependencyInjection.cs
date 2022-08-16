using CustomerClean.Application.Common.UploadFile;
using CustomerClean.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CustomerClean.Application.Common.Settings
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped<IMediator, Mediator>();
            services.AddScoped<IUploadService, UploadService>();


            services.AddDbContext<GeneralContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("GeneralContext")));

            return services;
        }
    }
}

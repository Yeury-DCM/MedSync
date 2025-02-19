
using MedSync.Core.Application.Interfaces.Services;
using MedSync.Core.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace MedSync.Core.Application
{
    public static class ServiceExtension
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            #region Services
          //  services.AddTransient<IAppoimentService, AppoimentService>();
            #endregion
        }
    }
}


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
            services.AddTransient<IAppoimentService, AppoimentService>();
            services.AddTransient<IDoctorOfficeService, DoctorOfficeService>();
            services.AddTransient<IDoctorService, DoctorService>();
            services.AddTransient<ILabResultService, LabResultService>();
            services.AddTransient<ILabTestService, LabTestService>();
            services.AddTransient<IPatientService, PatientService>();
            services.AddTransient<IUserService, UserService>();

            #endregion
        }
    }
}

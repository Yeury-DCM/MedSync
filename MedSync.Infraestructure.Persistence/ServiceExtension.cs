
using MedSync.Core.Application.Interfaces.Repositories;
using MedSync.Infraestructure.Persistence.Contexts;
using MedSync.Infraestructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MedSync.Infraestructure.Persistence
{
    public static class ServiceExtension
    {
        public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            #region Database Configuration
            if (configuration.GetValue<bool>("DataBaseInMemory"))
            {
                services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("MedSync"));
            }
            else
            {

                var connectionStrings = configuration.GetConnectionString("DefaultConnection");
                services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionStrings, m => m.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            }

            #endregion

            #region logger
            services.AddLogging();
            #endregion

            #region Repositories DI
            services.AddTransient<IAppoimentRepository, AppoimentRepository>();
            services.AddTransient<IDoctorRepository, DoctorRepository>();
            services.AddTransient<IDoctorOfficeRepository, DoctorOfficeRepository>();
            services.AddTransient<ILabResultRepository, LabResultRepository>();
            services.AddTransient<ILabTestRepository, LabTestRepository>();
            services.AddTransient<IPatientRepository, PatientRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            #endregion
        }
    }
}

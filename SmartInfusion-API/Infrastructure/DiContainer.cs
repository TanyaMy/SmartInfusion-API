using BusinessLayer.Services.Abstractions;
using BusinessLayer.Services.Implementations;
using Common.Constants;
using Common.Entities.Identity;
using DataLayer.DbContext;
using DataLayer.Repositories.Abstractions;
using DataLayer.Repositories.Implementations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SmartInfusion.API.Infrastructure
{
    public static class DiContainer
    {
        public static void AddCustomServices(IServiceCollection services)
        {
            // App Services
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(ConfigurationConstants.DbConnection), ServiceLifetime.Scoped);

            services.AddIdentity<AppUser, IdentityRole>(conf =>
            {
                conf.Password.RequiredLength = 6;
                conf.Password.RequireDigit = false;
                conf.Password.RequireLowercase = false;
                conf.Password.RequireUppercase = false;
                conf.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<AppDbContext>();


            // Data Layer
            services.AddTransient<IUserInfoRepository, UserInfoRepository>();
            services.AddTransient<IDiseaseHistoryRepository, DiseaseHistoryRepository>();
            services.AddTransient<IMedicineRepository, MedicineRepository>();
            services.AddTransient<IMetricsRepository, MetricsRepository>();
            services.AddTransient<ITreatmentRepository, TreatmentRepository>();


            // Business Layer
            services.AddTransient<IUserInfoService, UserInfoService>();
            services.AddTransient<IDiseaseHistoryService, DiseaseHistoryService>();
            services.AddTransient<IMedicineService, MedicineService>();
            services.AddTransient<IMetricsService, MetricsService>();
            services.AddTransient<ITreatmentService, TreatmentService>();

        }
    }
}

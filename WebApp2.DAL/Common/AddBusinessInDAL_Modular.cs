
using Microsoft.Extensions.DependencyInjection;
using WebApp2.DAL.Repo.Implementation;

namespace WebApp2.DAL.Common
{
    public static class AddBusinessInDAL_Modular
    {
        public static IServiceCollection AddBusniessInDAL(this IServiceCollection services) 
        {
            services.AddScoped<IEmployeeRepo, EmployeeRepo>();
            services.AddScoped<IDepartmentRepo, DepartmentRepo>();
            return services;
        }
    }
}

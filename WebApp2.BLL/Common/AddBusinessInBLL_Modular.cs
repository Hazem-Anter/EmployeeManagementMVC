using Microsoft.Extensions.DependencyInjection;
using WebApp2.BLL.Mapper;
using WebApp2.BLL.Service.Implementation;

namespace WebApp2.BLL.Common
{
    public static class AddBusinessInBLL_Modular
    {
        public static IServiceCollection AddBusinessInBLL(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));

            return services;
        }
    }
}

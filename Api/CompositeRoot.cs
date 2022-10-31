using Microsoft.Extensions.DependencyInjection;
using Service.IService;
using Service.Service;

namespace Api
{
    public static class CompositeRoot
    {
        public static void DependencyInjection(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IActivityService, ActivityService>();
        }
    }
}

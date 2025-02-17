
using OnlineMuhasebeServer.Presentation;
using OnlineMuhasebeServer.WebApi.Middlewares;

namespace OnlineMuhasebeServer.WebApi.Configurations
{
    public class PresentationServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ExceptionMiddleware>();
            services.AddControllers().AddApplicationPart(typeof(AssemblyReference).Assembly);

            services.AddOpenApi();
        }
    }
}

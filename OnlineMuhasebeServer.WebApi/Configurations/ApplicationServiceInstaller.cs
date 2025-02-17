
using OnlineMuhasebeServer.Application;

namespace OnlineMuhasebeServer.WebApi.Configurations
{
    public class ApplicationServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(AssemblyReference).Assembly));
        }
    }
}

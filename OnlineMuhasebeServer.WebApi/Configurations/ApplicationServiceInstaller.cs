
using FluentValidation;
using MediatR;
using OnlineMuhasebeServer.Application;
using OnlineMuhasebeServer.Application.Behaviors;

namespace OnlineMuhasebeServer.WebApi.Configurations
{
    public class ApplicationServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(AssemblyReference).Assembly));
            
            services.AddTransient(typeof(IPipelineBehavior<,>), (typeof(ValidationBehavior<,>)));

            services.AddValidatorsFromAssembly(typeof(AssemblyReference).Assembly);
        }
    }
}

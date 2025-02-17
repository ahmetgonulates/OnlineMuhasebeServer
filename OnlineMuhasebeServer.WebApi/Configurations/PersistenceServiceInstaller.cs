
using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;
using OnlineMuhasebeServer.Persistance.Contexts;

namespace OnlineMuhasebeServer.WebApi.Configurations
{
    public class PersistenceServiceInstaller : IServiceInstaller
    {

        private const string SectionName = "SqlServer";
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString(SectionName);
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString(SectionName)));
            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<AppDbContext>();

            services.AddAutoMapper(typeof(OnlineMuhasebeServer.Persistance.AssemblyReference).Assembly);
        }
    }
}

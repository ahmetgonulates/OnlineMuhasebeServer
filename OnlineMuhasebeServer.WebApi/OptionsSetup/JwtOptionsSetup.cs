using Microsoft.Extensions.Options;
using OnlineMuhasebeServer.Infrastructure.Authentication;

namespace OnlineMuhasebeServer.WebApi.OptionsSetup
{
    public class JwtOptionsSetup : IConfigureOptions<JwtOptions>
    {
        private readonly IConfiguration _configuration;

        public JwtOptionsSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(JwtOptions options)
        {
            _configuration.GetSection("JwtOptions").Bind(options); 
        }
    }
}

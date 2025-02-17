using Microsoft.AspNetCore.Identity;

namespace OnlineMuhasebeServer.Domain.AppEntities.Identity;

public class AppRole : IdentityRole<string>
{
    public string Code { get; set; }
}
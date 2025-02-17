using MediatR;
using Microsoft.AspNetCore.Identity;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;
using OnlineMuhasebeServer.WebApi.Configurations;
using OnlineMuhasebeServer.WebApi.Middlewares;


var builder = WebApplication.CreateBuilder(args);
builder.Services.InstallServices(builder.Configuration, typeof(IServiceInstaller).Assembly);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseExceptionMiddleware();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using (var scoped = app.Services.CreateScope())
{
    var userManager = scoped.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
    if (!userManager.Users.Any())
    {
        userManager.CreateAsync(new AppUser
        {
            UserName = "atg",
            Email = "gonulates.ahmet@gmail.com",
            Id = Guid.CreateVersion7().ToString(),
            NameLastName = "Ahmet Talha Gonulates"
        }, "Password12*").Wait();
    }
}


    app.Run();
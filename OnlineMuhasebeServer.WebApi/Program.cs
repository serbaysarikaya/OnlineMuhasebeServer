using Microsoft.AspNetCore.Identity;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;
using OnlineMuhasebeServer.WebApi.Configurations; // DI extension'ýn bulunduðu namespace

var builder = WebApplication.CreateBuilder(args);

// Tüm servis kurulumlarýnýn yapýlmasý (builder.Services hâlâ deðiþtirilmekte):
builder.Services.InstallServices(
    builder.Configuration,
    typeof(IServiceInstaller).Assembly // Modülleri tarayacak
);

var app = builder.Build();

// Uygulama baþladýktan SONRA middleware'ler eklenir.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

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
            UserName = "ssarikaya",
            Email = "serbaysarikaya@gmail.com",
            Id = Guid.NewGuid().ToString(),
            NameLastName = "Serbay Sarýkaya"
        }, "Password12*").Wait();
    }

}
app.Run();
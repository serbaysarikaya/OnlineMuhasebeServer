using Microsoft.AspNetCore.Identity;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;
using OnlineMuhasebeServer.WebApi.Configurations; // DI extension'�n bulundu�u namespace

var builder = WebApplication.CreateBuilder(args);

// T�m servis kurulumlar�n�n yap�lmas� (builder.Services h�l� de�i�tirilmekte):
builder.Services.InstallServices(
    builder.Configuration,
    typeof(IServiceInstaller).Assembly // Mod�lleri tarayacak
);

var app = builder.Build();

// Uygulama ba�lad�ktan SONRA middleware'ler eklenir.
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
            NameLastName = "Serbay Sar�kaya"
        }, "Password12*").Wait();
    }

}
app.Run();
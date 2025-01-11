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
app.Run();
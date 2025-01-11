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
app.Run();
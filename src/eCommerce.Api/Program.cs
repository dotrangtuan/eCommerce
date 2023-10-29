using eCommerce.Infrastructure;
using eCommerce.Infrastructure.Persistence;
using eCommerce.Shared.CoreSettings;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

var configuration = builder.Configuration;

// CoreSettings
CoreSetting.SetConnectionStrings(configuration);

// Add services to the container.

services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddInfrastructure();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


// Initialise and seed database
using (var scope = app.Services.CreateScope())
{
    var contextSeed = scope.ServiceProvider.GetRequiredService<ApplicationDbContextSeed>();
    await contextSeed.InitialiseAsync();
    await contextSeed.SeedAsync();
}


app.Run();
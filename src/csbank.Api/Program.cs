using CSbank.Infrastructure.Database.Connections;
using CSbank.Infrastructure.DI;
using CSBank.Api.DI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();

builder.Services.AddScoped<IDbConnectionFactory>(_ =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    return new PostgreSqlConnectionFactory(connectionString!);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

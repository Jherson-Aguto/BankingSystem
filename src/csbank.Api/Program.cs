
using CSBank.Infrastructure.DI;
using CSBank.Api.Middleware;
using CSBank.Application;
using CSBank.Api.Authentication;
using CSBank.Application.Models.Auth;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddExceptionHandler<ExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.Configure<JwtOptions>(
    builder.Configuration.GetSection("Jwt")
);
builder.Services.AddJwtAuthentication(builder.Configuration);

builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);


var app = builder.Build();

app.UseExceptionHandler();

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

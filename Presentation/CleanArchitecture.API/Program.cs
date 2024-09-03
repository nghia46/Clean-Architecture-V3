using CleanArchitecture.API.Extensions;
using CleanArchitecture.Application;
using CleanArchitecture.Infrastructure;
using CleanArchitecture.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

# region Layer Dependencies

builder.Services.AddApplicationDependencies();
builder.Services.AddPersistenceDependencies();
builder.Services.AddInfrastructureDependencies(builder.Configuration);

# endregion

// Add services to the container.
builder.Services.AddServiceExtensions(builder.Configuration);
// Add services to the container.
builder.Configuration.AddJsonFile("/app/config/appsettings.json", optional: true, reloadOnChange: true);

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
#region Swagger

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
        new Microsoft.OpenApi.Models.OpenApiInfo
        {
            Title = "Clean Architecture API",
            Description = "API for Clean Architecture",
            Version = "v1",
        });
});

#endregion

var app = builder.Build();

builder.Services.AddPreApplicationBuilder(app);

// Configure the HTTP request pipeline.

#region Middleware


#endregion

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Clean Architecture API V1");
    c.RoutePrefix = "";
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
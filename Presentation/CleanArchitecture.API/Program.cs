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

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

builder.Services.AddPreApplicationBuilder(app);

// Configure the HTTP request pipeline.

app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
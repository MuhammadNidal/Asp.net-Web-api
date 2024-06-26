using AutoMapper;
using Fophex.API.Dependencies;
using Fophex.API.Extensions;
using Fophex.API.Filters;
using Fophex.API.Middleware;
using Fophex.Application;
using Fophex.Application.Mapper;
using Fophex.Application.Shared.Tenant;
using Fophex.Application.Shared.Test;
using Fophex.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
//using Newtonsoft;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region AutoMapper
var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new EntityToDtoMapper());
    cfg.AddProfile(new DtoToEntityMapper());
});

var mapper = config.CreateMapper();

builder.Services.AddSingleton(mapper);
#endregion

builder.Services.AddScoped<ICurrentTenantService, CurrentTenantService>();

builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<FophexDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAndMigrateTenantDatabases(builder.Configuration);

builder.Services.RegisterServices();

// Add services to the container.
builder.Services.AddControllers(options =>
{
    //Add Your Filter
    options.Filters.Add<FophexValidationFilterAttribute>();
}).ConfigureApiBehaviorOptions(options =>
{
    //Disable The Default
    options.SuppressModelStateInvalidFilter = true;
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("*", builder =>
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseMiddleware<TenantResolver>();

app.UseMiddleware<FophexExceptionHandlingMiddleware>();
app.MapControllers();
app.UseCors("*");
app.Run();

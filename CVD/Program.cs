using Autofac;
using Autofac.Extensions.DependencyInjection;
using CVD.Domain;
using CVD.Extensions.AppSettings;
using CVD.IoC;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var services = builder.Services;
// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacModule()));

builder.Services.AddEntityFrameworkNpgsql().AddDbContext<CvdDbContext>(opt =>
    opt.UseNpgsql(configuration.GetConnectionString("CvdWebApiConnection")));

services.Configure<ConnectionOptions>(configuration.GetSection("ConnectionStrings"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();
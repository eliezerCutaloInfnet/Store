using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Store.Infra.CrossCutting;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("StoreDb");

// Add services to the container.
builder.Services.ConfigureAutoMapper();
builder.Services.RegisterServices();
builder.Services.ConfigureDbContext(connectionString);

builder.Services.AddControllers(options =>
{
    options.Filters.Add(new ServiceFilterAttribute(typeof(GlobalExceptionHandlerFilter)));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c=>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Store.Api", Version = "v1" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

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

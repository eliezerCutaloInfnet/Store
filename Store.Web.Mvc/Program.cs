using Store.Infra.CrossCutting;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("StoreDb");

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.ConfigureAutoMapper();
builder.Services.RegisterServices();
builder.Services.ConfigureDbContext(connectionString);



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

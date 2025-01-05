using AspnetCoreMvcStarter.Data;
using AspnetCoreMvcStarter.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Connect to the database
builder.Services.AddDbContext<AspnetCoreMvcStarterContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("AspnetCoreMvcStarterContext") ?? throw new InvalidOperationException("Connection string 'AspnetCoreMvcStarterContext' not found.")));

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();
// Create a service scope to get an AspnetCoreMvcStarterContext instance using DI and seed the database.
using (var scope = app.Services.CreateScope())
{
  var services = scope.ServiceProvider;

  SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    //pattern: "{controller=auth}/{action=LoginBasic}/{id?}");
    pattern: "{controller=home}/{action=index}/{id?}");


app.Run();

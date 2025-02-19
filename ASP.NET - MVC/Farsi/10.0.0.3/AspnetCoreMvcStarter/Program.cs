using AspnetCoreMvcStarter.Data;
using AspnetCoreMvcStarter.middleware;
using AspnetCoreMvcStarter.Models;
using AspnetCoreMvcStarter.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


// Connect to the database
builder.Services.AddDbContext<AspnetCoreMvcStarterContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("AspnetCoreMvcStarterContext") ?? throw new InvalidOperationException("Connection string 'AspnetCoreMvcStarterContext' not found.")));

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<ICrowdFundingService, CrowdFundingService>();
builder.Services.AddScoped<ITsetmcService, TsetmcService>();
builder.Services.AddScoped<OpenAiService>(); // ثبت OpenAiService
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR(); // اضافه کردن SignalR
// پیکربندی Serilog
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug() // سطح لاگ را تنظیم کنید (Debug، Information، Warning، Error، Fatal)
    .WriteTo.Console() // خروجی لاگ به کنسول
    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day) // خروجی لاگ به فایل
    .CreateLogger();

builder.Host.UseSerilog(); // استفاده از Serilog به عنوان لاگر

// افزودن Swagger
builder.Services.AddSwaggerGen(c =>
{
  c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});
var app = builder.Build();
// Create a service scope to get an AspnetCoreMvcStarterContext instance using DI and seed the database.
using (var scope = app.Services.CreateScope())
{
  var services = scope.ServiceProvider;

  SeedData.Initialize(services);
}
// ثبت Middleware سفارشی برای ثبت خطاها
app.UseMiddleware<ErrorLoggingMiddleware>();
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
// فعال‌سازی Swagger
app.UseSwagger();

// فعال‌سازی Swagger UI
app.UseSwaggerUI(c =>
{
  c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
  c.RoutePrefix = "swagger"; // مسیر Swagger UI را تنظیم کنید
});
app.UseEndpoints(endpoints =>
{
  endpoints.MapControllerRoute(
      name: "default",
      pattern: "{controller=Home}/{action=Index}/{id?}");

  endpoints.MapControllers(); // برای API
  endpoints.MapHub<OrderHub>("/orderHub"); // اضافه کردن Hub

});

app.Run();

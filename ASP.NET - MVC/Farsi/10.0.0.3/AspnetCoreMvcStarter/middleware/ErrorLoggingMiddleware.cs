namespace AspnetCoreMvcStarter.middleware;
using Microsoft.AspNetCore.Http;
using Serilog;
using System;
using System.Threading.Tasks;

public class ErrorLoggingMiddleware
{
  private readonly RequestDelegate _next;

  public ErrorLoggingMiddleware(RequestDelegate next)
  {
    _next = next;
  }

  public async Task InvokeAsync(HttpContext context)
  {
    try
    {
      await _next(context); // ادامه پردازش درخواست
    }
    catch (Exception ex)
    {
      // ثبت خطا در Serilog
      Log.Error(ex, "An unhandled exception has occurred while processing the request.");
      // می‌توانید یک پاسخ مناسب به کاربر ارسال کنید
      context.Response.StatusCode = StatusCodes.Status500InternalServerError;
      await context.Response.WriteAsync("An unexpected error occurred. Please try again later.");
    }
  }
}

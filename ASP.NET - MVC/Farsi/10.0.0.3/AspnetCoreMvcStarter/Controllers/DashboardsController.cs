using System.Diagnostics;
using AspnetCoreMvcStarter.Models.CrowdFunding;
using Microsoft.AspNetCore.Mvc;
using Mono.TextTemplating;

namespace AspnetCoreMvcStarter.Controllers;

public class DashboardsController : Controller
{
  public IActionResult Index() => View();
  public IActionResult CRM() => View();
  public IActionResult CF()
  {
    return View();
  }
  public IActionResult CF2() {
    // ساخت داده‌ها
    var model = new ShipmentStatistics
    {
      RequiredCapital = new[] { 95, 45, 33, 38, 32, 50, 48, 95, 42, 37 },
      InvestedCapital = new[] { 23, 28, 23, 32, 28, 44, 32, 38, 26, 34 }
    };

    return View(model); // ارسال مدل به نمای
  } 
  public IActionResult Project() => View();
  public IActionResult FinanceProvider() => View();
  public IActionResult ProfileProjects() => View();


}

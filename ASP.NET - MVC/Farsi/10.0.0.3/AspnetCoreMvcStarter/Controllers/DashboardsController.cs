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
  public IActionResult Kpi() {

    return View(); // ارسال مدل به نمای
  } 
  public IActionResult Project() => View();
  public IActionResult FinanceProvider() => View();
  public IActionResult ProfileProjects() => View();


}

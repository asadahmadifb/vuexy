using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspnetCoreMvcFull.Models;

namespace AspnetCoreMvcFull.Controllers;

public class DashboardsController : Controller
{
  public IActionResult Index() => View();
  public IActionResult CRM() => View();
  public IActionResult CF() => View();
  public IActionResult CF2() => View();
  public IActionResult Project() => View();
  public IActionResult FinanceProvider() => View();
  

}

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace AspnetCoreMvcStarter.Controllers;

public class AiController : Controller
{
  public IActionResult Chat() => View();
  public IActionResult Chatdb() => View();
  public IActionResult Chatagent() => View();
  public IActionResult Chatdb2() => View();

  public IActionResult DashboardAi()
  {
    return View();
  }

  public IActionResult MonitoringAi()
  {
    return View();
  }

}

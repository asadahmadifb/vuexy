using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace AspnetCoreMvcStarter.Controllers;

public class FrontPagesController : Controller
{
  public IActionResult HelpCenterLanding() => View();
}

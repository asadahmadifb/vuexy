using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace AspnetCoreMvcFull.Controllers;

public class FrontPagesController : Controller
{
  public IActionResult HelpCenterLanding() => View();
}

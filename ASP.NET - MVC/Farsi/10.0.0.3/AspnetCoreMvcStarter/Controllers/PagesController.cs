using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace AspnetCoreMvcStarter.Controllers;

public class PagesController : Controller
{
  public IActionResult ProfileProjects() => View();
}

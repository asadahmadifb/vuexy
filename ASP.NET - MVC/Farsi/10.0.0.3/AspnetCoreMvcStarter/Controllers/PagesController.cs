using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace AspnetCoreMvcFull.Controllers;

public class PagesController : Controller
{
  public IActionResult ProfileProjects() => View();
}

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspnetCoreMvcFull.Models;

namespace AspnetCoreMvcFull.Controllers;

public class CalendarController : Controller
{
  public IActionResult Calendar() => View();
  public IActionResult CalendarJalali() => View();
}

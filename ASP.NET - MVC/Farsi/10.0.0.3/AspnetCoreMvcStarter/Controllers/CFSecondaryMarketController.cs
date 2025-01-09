using Microsoft.AspNetCore.Mvc;

namespace AspnetCoreMvcStarter.Controllers
{
   public class CFSecondaryMarketController : Controller
    {
      public IActionResult Order() => View();
      public IActionResult Setting() => View();


  }
}

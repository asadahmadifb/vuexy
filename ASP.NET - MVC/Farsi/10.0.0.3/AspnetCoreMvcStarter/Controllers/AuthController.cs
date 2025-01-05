using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace AspnetCoreMvcStarter.Controllers;

public class AuthController : Controller
{
  [HttpGet]
  public IActionResult LoginBasic() => View();
  [HttpPost]
  public IActionResult LoginBasic(string emailUsername, string password)
  {
    // اعتبارسنجی کاربر (این قسمت باید به نیازهای شما بستگی داشته باشد)
    if (emailUsername == "asadahmadibm" && password == "Aa@123456") // جایگزین yourPassword با رمز واقعی
    {
      // در اینجا می‌توانید کاربر را به صفحه اصلی هدایت کنید
      return RedirectToAction("CF", "Dashboards");
    }
    else
    {
      // در صورت عدم موفقیت، می‌توانید یک پیام خطا نمایش دهید
      ViewBag.ErrorMessage = "ایمیل یا رمز عبور نادرست است.";
      return View();
    }
  }
}

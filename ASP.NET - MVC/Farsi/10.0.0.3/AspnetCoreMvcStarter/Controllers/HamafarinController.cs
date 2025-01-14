using System.Diagnostics;
using System.Net.Http.Headers;
using AspnetCoreMvcStarter.Models.CrowdFunding;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using AspnetCoreMvcStarter.Migrations;

namespace AspnetCoreMvcStarter.Controllers;

public class HamafarinController : Controller
{
  public async Task<IActionResult> Index()
  {
    var url = "https://hamafarin.ir/"; // آدرس URL صفحه‌ای که می‌خواهید کرال کنید
    var businessPlans = await CrawlBoard(url);
    return View(businessPlans);
  }
  private async Task<List<BusinessPlan>> CrawlBoard(string url)
  {
    string seleniumManagerPath = Path.Combine(AppContext.BaseDirectory, "chromedriver", "chromedriver.exe");
    if(!System.IO.File.Exists(seleniumManagerPath))
    {
      Console.WriteLine("ChromeDriver not found at the specified path.");
      return new List<BusinessPlan>(); ;
    }
    var service = ChromeDriverService.CreateDefaultService(seleniumManagerPath);
    var options = new ChromeOptions();
    options.AddArgument("--headless"); // برای اجرای بدون نمایش مرورگر
    options.AddArgument("--no-sandbox");
    options.AddArgument("--disable-dev-shm-usage");
    options.AddArgument("start-maximized");

    using (var driver = new ChromeDriver(service, options))
    {
      driver.Navigate().GoToUrl(url);
      await Task.Delay(2000); // زمان برای بارگذاری صفحه
      System.Threading.Thread.Sleep(2000); // وقفه به مدت 1 ثانیه

      var data = new List<BusinessPlan>();
      var items = driver.FindElements(By.CssSelector("div.col-xl-4.col-lg-4.col-md-6.col-sm-12.col-12.my-2"));

      foreach (var item in items)
      {
        var linkElement = item.FindElement(By.CssSelector("a.text-dark"));
        var titleElement = item.FindElement(By.CssSelector("h2.card-title.font-weight-bold.FontLarger"));
        // پیدا کردن <div> خاص و استخراج تمام <p> ها
        var specificDiv = item.FindElement(By.CssSelector("div.col-12.p-0"));
        var paragraphs = specificDiv.FindElements(By.TagName("p")); // پیدا کردن همه <p> ها

        // استخراج متن از همه <p> ها
        var paragraphTexts = new List<string>();
        foreach (var paragraph in paragraphs)
        {
          paragraphTexts.Add(paragraph.Text); // متن هر <p> را به لیست اضافه می‌کند
        }
        var financialInfoNode = item.FindElement(By.CssSelector("div.row.mt-2.text-center"));

        var goalAmount = financialInfoNode.FindElement(By.CssSelector("div.col-5 p")).Text; // مبلغ هدف
        var investorsCount = financialInfoNode.FindElement(By.CssSelector("div.col-3 p")).Text; // تعداد سرمایه‌گذاران
        var profitForecast = financialInfoNode.FindElement(By.CssSelector("div.col-4 p")).Text; // پیش‌بینی سود

        var sections = paragraphTexts[1].Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
        var xx = sections.Length;

        var businessPlan = new BusinessPlan
        {
          Title = titleElement.Text,
          //Link = linkElement.GetDomAttribute("href"), // تغییر به GetDomAttribute
          ProfitPrediction = string.Join(Environment.NewLine, paragraphTexts), // تبدیل لیست به رشته
          p1= sections.Length>0 ? sections[0].Trim().Replace("پیش‌بینی‌میزان‌سود: ","") : "",
          p2 = sections.Length > 0 ? sections[1].Trim() : "",
          p3 = sections.Length > 0 ? sections[2].Trim() : "",
          p4 = paragraphTexts[2].Replace("شروع: ",""),
          GoalAmount = goalAmount,  
          InvestorsCount = investorsCount,
          ProfitForecast = profitForecast
        };                          
                                    
        data.Add(businessPlan);     
      }                             
      return data;                  
    }
  }
}

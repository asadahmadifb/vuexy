using System.Diagnostics;
using AspnetCoreMvcStarter.Models.CrowdFunding;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;

namespace AspnetCoreMvcStarter.Controllers;

public class BoardController : Controller
{
  private readonly HttpClient _httpClient;

  public BoardController()
  {
    _httpClient = new HttpClient();
  }

  public async Task<IActionResult> Index()
  {
    string url = "https://cfai.ir/Dashboards/ProfileProjects"; // آدرس سایتی که می‌خواهید کرال کنید
    var data = await CrawlBoard(url);
    return View(data);
  }
  private async Task<List<BoardData>> CrawlBoard(string url)
  {
    var data = new List<BoardData>();
    var response = await _httpClient.GetStringAsync(url);

    var htmlDoc = new HtmlDocument();
    htmlDoc.LoadHtml(response);

    //var cards = htmlDoc.DocumentNode.SelectNodes("//div[contains(@class, 'card')]");
    //var cards = htmlDoc.DocumentNode.SelectNodes("//div[contains(@class, 'row')]//div[contains(@class, 'card')]");
    var rows = htmlDoc.DocumentNode.SelectNodes("//div[contains(@class, 'row g-4')]");

    if (rows != null)
    {
      foreach (var row in rows)
      {
        // پیدا کردن کارت‌ها داخل هر ردیف
        var cards = row.SelectNodes(".//div[contains(@class, 'card')]");

        if (cards != null)
        {

          foreach (var card in cards)
          {
            var title = card.SelectSingleNode(".//h5")?.InnerText.Trim() ?? string.Empty;
            var client = card.SelectSingleNode(".//div[contains(@class, 'client-info')]//span[2]")?.InnerText.Trim() ?? string.Empty;
            var budget = card.SelectSingleNode(".//h6[contains(@class, 'mb-0')]//bdi")?.InnerText.Trim() ?? string.Empty;
            var startDate = card.SelectSingleNode(".//h6[contains(text(), 'تاریخ شروع:')]//span")?.InnerText.Trim() ?? string.Empty;
            var endDate = card.SelectSingleNode(".//h6[contains(text(), 'تاریخ اتمام:')]//span")?.InnerText.Trim() ?? string.Empty;
            var description = card.SelectSingleNode(".//p[contains(@class, 'mb-0')]")?.InnerText.Trim() ?? string.Empty;
            var totalHours = card.SelectSingleNode(".//h6[contains(text(), 'تمام ساعات:')]//span")?.InnerText.Trim() ?? string.Empty;

            var taskInfo = card.SelectNodes(".//small");
            var taskCount = taskInfo != null && taskInfo.Count > 0 ? taskInfo[0].InnerText.Trim() : string.Empty;
            var completionRate = taskInfo != null && taskInfo.Count > 1 ? taskInfo[1].InnerText.Trim() : string.Empty;

            data.Add(new BoardData
            {
              Title = title,
              Client = client,
              Budget = budget,
              StartDate = startDate,
              EndDate = endDate,
              Description = description,
              TotalHours = totalHours,
              TaskCount = taskCount,
              CompletionRate = completionRate
            });
          }
        }
      }
    }
    return data;
  }
}

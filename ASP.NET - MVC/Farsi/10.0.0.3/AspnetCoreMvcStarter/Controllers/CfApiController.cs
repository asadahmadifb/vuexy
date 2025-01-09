using AspnetCoreMvcStarter.Content;
using AspnetCoreMvcStarter.Data;
using AspnetCoreMvcStarter.Models;
using AspnetCoreMvcStarter.Models.CrowdFunding;
using AspnetCoreMvcStarter.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace AspnetCoreMvcStarter.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CfApiController : ControllerBase
  {
    private readonly ICrowdFundingService _CrowdFundingService;
    private readonly AspnetCoreMvcStarterContext _context;
     public CfApiController(ICrowdFundingService CrowdFundingService, AspnetCoreMvcStarterContext context)
    {
      _CrowdFundingService = CrowdFundingService;
      _context = context;
    }
    [HttpGet]
    public async Task<IActionResult> GetExamples()
    {

      // ایجاد لیست برای ذخیره نتایج
      var examples = new List<object>();
      try
      {

        var questionHistories = _context.QuestionHistories.ToList();


        // برای هر سوال، داده‌های CrowdFunding را دریافت کنید
        foreach (var item in questionHistories)
        {
          string jsonResult = "";
          List<dynamic> response =new List<dynamic>();
          try
          {
            response = await _CrowdFundingService.GetDataFromCF(item.response.Replace("\n", " ").Trim());

          }
          catch (Exception)
          {
          }
          jsonResult = JsonConvert.SerializeObject(response, Formatting.Indented);
          examples.Add(new
          {
            item.question,
            item.response,
            crowdfundingdata = jsonResult
          });
        }
      }
      catch (Exception ex)
      {

        throw;
      }


      // داده‌ها را به فرمت JSON برمی‌گرداند
      return Ok(examples);
    }

    [HttpGet("GetAllData")]
    public async Task<IActionResult> GetAllData()
    {
      var data = await _context.DashboardData.FirstOrDefaultAsync();

      return Ok(data);
    }
    [HttpPost("UpdateAllData")]
    public async Task<IActionResult> UpdateAllData([FromBody] DashboardData newData)
    {
      if (newData == null)
      {
        return BadRequest("داده‌های ورودی معتبر نیستند");
      }

      // به‌روزرسانی یا اضافه کردن داده‌ها
      var existingData = await _context.DashboardData.FirstOrDefaultAsync();
      if (existingData != null)
      {
        // به‌روزرسانی داده‌های موجود
        existingData.Started = newData.Started;
        existingData.OtherStarted = newData.OtherStarted;
        existingData.FundingFinished = newData.FundingFinished;
        existingData.OtherFundingFinished = newData.OtherFundingFinished;
        existingData.ApprovedByBroker = newData.ApprovedByBroker;
        existingData.OtherApprovedByBroker = newData.OtherApprovedByBroker;
        existingData.FundingApprovedByFarabourse = newData.FundingApprovedByFarabourse;
        existingData.OtherFundingApprovedByFarabourse = newData.OtherFundingApprovedByFarabourse;

        _context.DashboardData.Update(existingData);
      }
      else
      {
        // اگر داده‌ای وجود ندارد، داده جدید را اضافه کنید
        await _context.DashboardData.AddAsync(newData);
      }

      await _context.SaveChangesAsync();

      return Ok(newData);
     }
    [HttpGet("GetShipmentStatistics")]
    public async Task<IActionResult> GetShipmentStatistics()
    {
      // داده‌های نمونه
      var data = new
      {
        RequiredCapital = new[] { 38, 45, 33, 38, 32, 50, 48, 40, 42, 37 },
        InvestedCapital = new[] { 23, 28, 23, 32, 28, 44, 32, 38, 26, 34 }
      };

      return Ok(data); // برگرداندن داده‌ها به صورت JSON
    }

    [HttpPost("SendMessage")]
    public async Task<ActionResult> SendMessage([FromBody] Message messageContent)
    {

      var openAiService = new OpenAiService();
      string tableStructure = Contents.GettableStructure("vw_Projects");
      string answer = await openAiService.GetSqlQueryFromOpenAi(messageContent.Content ?? "", tableStructure);
      answer = answer.Substring(6);
      answer = answer.Substring(0, answer.Length - 4);


      if (!string.IsNullOrWhiteSpace(messageContent.Content))
      {
        var questionHistory = new QuestionHistory
        {
          question = messageContent.Content,
          response = answer.Trim(),
          selectedOption = "CrowdFunding",
          Timestamp = DateTime.Now,
          isDelete = false,
          UserId = "CF"// دریافت شناسه کاربر

        };
        _context.QuestionHistories.Add(questionHistory);
        _context.SaveChanges();

      }
      string jsonResult = "";
      try
      {
        var response = await _CrowdFundingService.GetDataFromCF(answer.Replace("\n", " ").Trim());
        jsonResult = JsonConvert.SerializeObject(response, Formatting.Indented);
        //foreach (dynamic row in response)
        //{
        //    // دریافت نام ستون‌ها و مقادیر
        //    var dictionary = (IDictionary<string, object>)row;
        //    foreach (var kvp in dictionary)
        //    {
        //        Console.WriteLine($"Column Name: {kvp.Key}, Value: {kvp.Value}");
        //    }
        //    Console.WriteLine(); // برای جداسازی هر ردیف
        //}
      }
      catch (Exception ex)
      {
        jsonResult = ex.Message;
      }



      //string responseMessage = answer.Trim() + Environment.NewLine + jsonResult; // اینجا به سادگی یک پاسخ نمونه برمی‌گردانیم
      string responseMessage = jsonResult; // اینجا به سادگی یک پاسخ نمونه برمی‌گردانیم

      // می‌توانید منطق پیچیده‌تری برای تولید پاسخ ایجاد کنید

      return Ok(responseMessage); // برگرداندن پاسخ به صورت JSON
    }
  }
}

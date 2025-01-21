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
  public class AiApiController : ControllerBase
  {
    private readonly ICrowdFundingService _CrowdFundingService;
    private readonly AspnetCoreMvcStarterContext _context;
     public AiApiController(ICrowdFundingService CrowdFundingService, AspnetCoreMvcStarterContext context)
    {
      _CrowdFundingService = CrowdFundingService;
      _context = context;
    }
    [HttpGet("GetQuestion")]
    public async Task<IActionResult> GetQuestion()
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
            item.Id,
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

    [HttpPost("SendQuestion")]
    public async Task<ActionResult> SendQuestion([FromBody] Message messageContent)
    {

      var openAiService = new OpenAiService();
      string tableStructure = Contents.GettableStructure("vw_Projects");
      //string tableStructure = Contents.GettableStructure("Projectinfo");
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

    [HttpPost("SendQuestionfromagent")]
    public async Task<ActionResult> SendQuestionfromagent([FromBody] Message messageContent)
    {

      var openAiService = new OpenAiService();
      List<ProjectView> projectViews = await _CrowdFundingService.GetListAllOfProjects();
      string answer = await openAiService.GetQuestionFromOpenAi(messageContent.Content ?? "", projectViews);

      //if (!string.IsNullOrWhiteSpace(messageContent.Content))
      //{
      //  var questionHistory = new QuestionHistory
      //  {
      //    question = messageContent.Content,
      //    response = answer.Trim(),
      //    selectedOption = "CrowdFunding",
      //    Timestamp = DateTime.Now,
      //    isDelete = false,
      //    UserId = "CF"// دریافت شناسه کاربر

      //  };
      //  _context.QuestionHistories.Add(questionHistory);
      //  _context.SaveChanges();

      //}
      string jsonResult = "";
      try
      {
        jsonResult = JsonConvert.SerializeObject(answer, Formatting.Indented);
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

    

    [HttpDelete("deletechat/{id}")]
    public IActionResult deletechat(int id)
    {
      var itemToRemove = _context.QuestionHistories.FirstOrDefault(item => item.Id == id);
      if (itemToRemove == null)
      {
        return NotFound(); // اگر آیتم پیدا نشد، 404 بازگردانده می‌شود
      }

      _context.QuestionHistories.RemoveRange(itemToRemove);
      _context.SaveChanges();

      // می‌توانید داده‌های جدید را به صورت JSON برگردانید
      return Ok("success"); // برگرداندن پاسخ به صورت JSON
    }

  }
}

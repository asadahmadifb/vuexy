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


    [HttpGet("GetProjectStatusCounts")]
    public async Task<IActionResult> GetProjectStatusCountsAsync()
    {
      var data = await _CrowdFundingService.GetProjectCountBystatus();
      return Ok(data);
    }


    [HttpGet("GetProjectFinancingSummary")]
    public async Task<IActionResult> GetProjectFinancingSummaryAsync()
    {
      var data = await _CrowdFundingService.GetProjectFinancingSummary();
      return Ok(data);
    }

    [HttpGet("GetProjectCountBystatus")]
    public async Task<IActionResult> GetProjectCountBystatus()
    {
      var data = await _context.DashboardData.FirstOrDefaultAsync();
      return Ok(data);
    }


    [HttpGet("GetProjectCountByMonth")]
    public async Task<IActionResult> GetProjectCountByMonth()
    {
      var projectsnew = await _CrowdFundingService.GetUnderwritingByYear();
      var year1403=projectsnew.Where(it => it.Year == 1403).ToList();
      // ایجاد آرایه‌ای برای ذخیره مقادیر TotalPrice برای هر ماه
      var monthlyTotalPrices = new long[12]; // 12 ماه
      var monthlyTotalProject = new int[12]; // 12 ماه

      // جمع‌آوری TotalPrice برای هر ماه
      foreach (var project in year1403)
      {
        double x = (double)project.TotalPrice / 1000000000;
        double res = Math.Round(x, 1);
        monthlyTotalPrices[project.Month - 1] += (long)res;  // ماه‌ها از 1 تا 12 هستند، بنابراین باید 1 را از آن کم کنیم
        monthlyTotalProject[project.Month - 1] += project.ProjectCount;
      }
      // ساخت داده‌ها
      var model = new ShipmentStatistics
      {
        RequiredCapital = monthlyTotalPrices,
        InvestedCapital = monthlyTotalProject
      };
      return Ok(model);
    }


    [HttpPost("UpdateProjectCountBystatus")]
    public async Task<IActionResult> UpdateProjectCountBystatus([FromBody] DashboardData newData)
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

    [HttpGet("GetListAllOfProjects")]
    public async Task<IActionResult> GetListAllOfProjects()
    {
      var projectsnew = await _CrowdFundingService.GetProjects();
      return Ok(projectsnew);
      var data = await _context.ProjectViews.ToListAsync();


    }

    [HttpGet("GetAllProject")]
    public async Task<IActionResult> GetAllProject()
    {
      var projectsnew = await _CrowdFundingService.GetAllProject();
      return Ok(projectsnew);

    }
    [HttpGet("GetUnderwritingByYear")]
    public async Task<IActionResult> GetUnderwritingByYear()
    {
      var projectsnew = await _CrowdFundingService.GetUnderwritingByYear();
      // ساختار داده جدید
      List<ChartData> chartDataList = new List<ChartData>();

      // گروه‌بندی داده‌ها بر اساس سال
      var groupedData = GroupByYear(projectsnew);

      foreach (var yearGroup in groupedData)
      {
        ChartData chartData = new ChartData
        {
          Id = yearGroup.Key,
          chart_data = new List<Int64>(new Int64[12]), // ایجاد یک لیست با 12 عنصر صفر
          active_option=2
        };

        foreach (var data in yearGroup.Value) // استفاده از yearGroup.Value برای دسترسی به لیست
        {
          chartData.chart_data[data.Month - 1] = data.ProjectCount; // مقدار پروژه را در موقعیت مناسب قرار دهید
        }

        chartDataList.Add(chartData);
      }
      return Ok(chartDataList);

    }

    private static Dictionary<int, List<UnderwritingByYear>> GroupByYear(List<UnderwritingByYear> data)
    {
        var result = new Dictionary<int, List<UnderwritingByYear>>();

        foreach (var item in data)
        {
            if (!result.ContainsKey(item.Year))
            {
                result[item.Year] = new List<UnderwritingByYear>();
            }
            result[item.Year].Add(item);
        }

        return result;
    }

  }
}

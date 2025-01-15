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

    [HttpGet("GetProjectCountBystatus")]
    public async Task<IActionResult> GetProjectCountBystatus()
    {
      var data = await _context.DashboardData.FirstOrDefaultAsync();

      return Ok(data);
    }


    [HttpGet("GetProjectCountByMonth")]
    public async Task<IActionResult> GetProjectCountByMonth()
    {
      // ساخت داده‌ها
      var model = new ShipmentStatistics
      {
        RequiredCapital = new[] { 95, 45, 33, 38, 32, 50, 48, 95, 42, 37 },
        InvestedCapital = new[] { 23, 28, 23, 32, 28, 44, 32, 38, 26, 34 }
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



  }
}

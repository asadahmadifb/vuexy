using AspnetCoreMvcStarter.Content;
using AspnetCoreMvcStarter.Data;
using AspnetCoreMvcStarter.Models;
using AspnetCoreMvcStarter.Models.CrowdFunding;
using AspnetCoreMvcStarter.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using static NuGet.Packaging.PackagingConstants;

namespace AspnetCoreMvcStarter.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CfSecondaryMarketApiController : ControllerBase
  {
    private readonly ICrowdFundingService _CrowdFundingService;
    private readonly AspnetCoreMvcStarterContext _context;
    private readonly IHubContext<OrderHub> _hubContext;

    public CfSecondaryMarketApiController(IHubContext<OrderHub> hubContext,ICrowdFundingService CrowdFundingService, AspnetCoreMvcStarterContext context)
    {
      _CrowdFundingService = CrowdFundingService;
      _context = context;
      _hubContext = hubContext;

    }

    [HttpGet("GetAllOrder")]
    public async Task<IActionResult> GetAllOrder()
    {

      var data = await _context.Orders.ToListAsync();
      return Ok(data);
    }
    [HttpGet("GetSaleOrder")]
    public async Task<IActionResult> GetSaleOrder()
    {

      var data = await _context.Orders.Where(it => it.Status == 0).OrderByDescending(it => it.StartTime).ToListAsync();
      return Ok(data);
    }
    [HttpGet("GetBuyOrder")]
    public async Task<IActionResult> GetBuyOrder()
    {

      var data = await _context.Orders.Where(it=>it.Status==1).OrderByDescending(it=>it.StartTime).ToListAsync();
      return Ok(data);
    }
    [HttpPost("InsertOrder")]
    public async Task<IActionResult> InsertOrder([FromBody] Order newData)
    {
      if (newData == null)
      {
        return BadRequest("داده‌های ورودی معتبر نیستند");
      }

      // به‌روزرسانی یا اضافه کردن داده‌ها
      // اگر داده‌ای وجود ندارد، داده جدید را اضافه کنید
        await _context.Orders.AddAsync(newData);
        await _context.SaveChangesAsync();
        await _hubContext.Clients.All.SendAsync("ReceiveOrderUpdate", newData);

      return Ok(newData);
     }

    [HttpGet("DeleteBuy")]
    public async Task<IActionResult> DeleteBuy()
    {

      var data = await _context.Orders.Where(it => it.Status == 1).ToListAsync();
      if (data!=null)
      {
        _context.Orders.RemoveRange(data);
        _context.SaveChanges();

      }
      return Ok();
    }
    [HttpGet("DeleteSale")]
    public async Task<IActionResult> DeleteSale()
    {

      var data = await _context.Orders.Where(it => it.Status == 0).ToListAsync();
      if (data != null)
      {
        _context.Orders.RemoveRange(data);
        _context.SaveChanges();

      }
      return Ok();
    }
    
  }
}

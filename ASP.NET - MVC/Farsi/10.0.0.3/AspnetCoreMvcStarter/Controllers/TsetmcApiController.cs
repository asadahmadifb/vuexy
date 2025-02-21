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
  public class TsetmcApiController : ControllerBase
  {
    private readonly ITsetmcService _tsetmcService ;
    private readonly AspnetCoreMvcStarterContext _context;
     public TsetmcApiController(ITsetmcService tsetmcService, AspnetCoreMvcStarterContext context)
    {
      _tsetmcService = tsetmcService;
      _context = context;
    }




    [HttpGet("GetInstrumentList")]
    public async Task<IActionResult> GetInstrumentList()
    {
      var data = await _tsetmcService.GetInstrumentAsync();
      return Ok(data);
    }



    [HttpGet("GetClosingPriceDailyList")]
    public async Task<IActionResult> GetClosingPriceDailyList(string insCode)
    {
      var data = await _tsetmcService.GetClosingPricesAsync(insCode, 2500);
      return Ok(data);
    }


    [HttpGet("GetInstrumentShareChange")]
    public async Task<IActionResult> GetInstrumentShareChange(string insCode)
    {
      var data = await _tsetmcService.GetInstrumentShareChangeAsync(insCode);
      return Ok(data);
    }

    [HttpGet("GetPriceAdjustList")]
    public async Task<IActionResult> GetPriceAdjustList(string insCode)
    {
      var data = await _tsetmcService.GetPriceAdjustAsync(insCode);
      return Ok(data);
    }


  }
}

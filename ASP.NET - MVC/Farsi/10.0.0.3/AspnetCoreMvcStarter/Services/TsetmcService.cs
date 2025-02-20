using System.Globalization;
using AspnetCoreMvcStarter.Models.Tsetmc;

namespace AspnetCoreMvcStarter.Services
{
  public class TsetmcService : ITsetmcService
  {
    private static readonly HttpClient _httpClient = new HttpClient();

    public async Task<List<ClosingPriceDTO>> GetClosingPricesAsync(string isnCode,int recordCount)
    {
      string url = @"https://cdn.tsetmc.com/api/ClosingPrice/GetClosingPriceDailyList/"+isnCode+"/"+recordCount;
      try
      {
        // Send GET request
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        // Deserialize the JSON response into ClosingPriceResponse
        var closingPriceResponse = await response.Content.ReadFromJsonAsync<ClosingPriceResponse>();

        // Return the list of closing prices
        var list=closingPriceResponse?.ClosingPriceDaily ?? new List<ClosingPrice>();
        return list.Select(it=>new ClosingPriceDTO
        {
          Open=it.PriceFirst,
          Close=it.PClosing,
          Low=it.PriceMin,
          High=it.PriceMax,
          InsCode=it.InsCode,
          PriceYesterday=it.PriceYesterday,
          DEven=it.DEven,
          PersianDate = $"{new PersianCalendar().GetYear(new DateTime(int.Parse(it.DEven.ToString().Substring(0, 4)), int.Parse(it.DEven.ToString().Substring(4, 2)), int.Parse(it.DEven.ToString().Substring(6, 2))))}/{new PersianCalendar().GetMonth(new DateTime(int.Parse(it.DEven.ToString().Substring(0, 4)), int.Parse(it.DEven.ToString().Substring(4, 2)), int.Parse(it.DEven.ToString().Substring(6, 2)))):D2}/{new PersianCalendar().GetDayOfMonth(new DateTime(int.Parse(it.DEven.ToString().Substring(0, 4)), int.Parse(it.DEven.ToString().Substring(4, 2)), int.Parse(it.DEven.ToString().Substring(6, 2)))):D2}"
        }).OrderBy(it=>it.DEven).ToList();
      }
      catch (Exception ex)
      {
        // Handle exceptions (log or rethrow)
        Console.WriteLine($"An error occurred: {ex.Message}");
        return new List<ClosingPriceDTO>();
      }
    }

    public async Task<List<TradeTopDTO>> GetInstrumentAsync()
    {
      string url = "https://cdn.tsetmc.com/api/ClosingPrice/GetTradeTop/MostVisited/1/99999";
      try
      {
        // Send GET request
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        // Deserialize the JSON response into ClosingPriceResponse
        var closingPriceResponse = await response.Content.ReadFromJsonAsync<TradeTopResponse>();

        // Return the list of closing prices
        var list = closingPriceResponse?.TradeTop ?? new List<TradeTop>();
        return list.Select(it => new TradeTopDTO
        {
          InsCode = it.insCode,
          SymbolName=it.instrument.lVal18AFC,
          LVal30= it.instrument.lVal30

        }).ToList();
      }
      catch (Exception ex)
      {
        // Handle exceptions (log or rethrow)
        Console.WriteLine($"An error occurred: {ex.Message}");
        return new List<TradeTopDTO>();
      }
    }

    public async Task<List<InstrumentShareChangeDTO>> GetInstrumentShareChangeAsync(string isnCode)
    {
      string url = @"https://cdn.tsetmc.com/api/Instrument/GetInstrumentShareChange/" + isnCode ;
      try
      {
        // Send GET request
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        // Deserialize the JSON response into ClosingPriceResponse
        var closingPriceResponse = await response.Content.ReadFromJsonAsync<InstrumentShareChangeResponse>();

        // Return the list of closing prices
        var list = closingPriceResponse?.instrumentShareChange ?? new List<InstrumentShareChange>();
        return list.Select(it => new InstrumentShareChangeDTO
        {
          InsCode = it.InsCode,
          NumberOfShareOld = it.NumberOfShareOld,
          NumberOfShareNew = it.NumberOfShareNew,
          Diff= it.NumberOfShareNew- it.NumberOfShareOld,
          DEven = it.DEven,
          PersianDate = $"{new PersianCalendar().GetYear(new DateTime(int.Parse(it.DEven.ToString().Substring(0, 4)), int.Parse(it.DEven.ToString().Substring(4, 2)), int.Parse(it.DEven.ToString().Substring(6, 2))))}/{new PersianCalendar().GetMonth(new DateTime(int.Parse(it.DEven.ToString().Substring(0, 4)), int.Parse(it.DEven.ToString().Substring(4, 2)), int.Parse(it.DEven.ToString().Substring(6, 2)))):D2}/{new PersianCalendar().GetDayOfMonth(new DateTime(int.Parse(it.DEven.ToString().Substring(0, 4)), int.Parse(it.DEven.ToString().Substring(4, 2)), int.Parse(it.DEven.ToString().Substring(6, 2)))):D2}"
        }).ToList();
      }
      catch (Exception ex)
      {
        // Handle exceptions (log or rethrow)
        Console.WriteLine($"An error occurred: {ex.Message}");
        return new List<InstrumentShareChangeDTO>();
      }
    }

    public async Task<List<PriceAdjustDTO>> GetPriceAdjustAsync(string isnCode)
    {
      string url = @"https://cdn.tsetmc.com/api/ClosingPrice/GetPriceAdjustList/" + isnCode;
      try
      {
        // Send GET request
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        // Deserialize the JSON response into ClosingPriceResponse
        var closingPriceResponse = await response.Content.ReadFromJsonAsync<PriceAdjustResponse>();

        // Return the list of closing prices
        var list = closingPriceResponse?.PriceAdjust ?? new List<PriceAdjust>();
        return list.Select(it => new PriceAdjustDTO
        {
          InsCode = it.InsCode,
          Diff = it.PClosingNotAdjusted - it.PClosing,
          DEven = it.DEven,
          PersianDate = $"{new PersianCalendar().GetYear(new DateTime(int.Parse(it.DEven.ToString().Substring(0, 4)), int.Parse(it.DEven.ToString().Substring(4, 2)), int.Parse(it.DEven.ToString().Substring(6, 2))))}/{new PersianCalendar().GetMonth(new DateTime(int.Parse(it.DEven.ToString().Substring(0, 4)), int.Parse(it.DEven.ToString().Substring(4, 2)), int.Parse(it.DEven.ToString().Substring(6, 2)))):D2}/{new PersianCalendar().GetDayOfMonth(new DateTime(int.Parse(it.DEven.ToString().Substring(0, 4)), int.Parse(it.DEven.ToString().Substring(4, 2)), int.Parse(it.DEven.ToString().Substring(6, 2)))):D2}"
        }).ToList();
      }
      catch (Exception ex)
      {
        // Handle exceptions (log or rethrow)
        Console.WriteLine($"An error occurred: {ex.Message}");
        return new List<PriceAdjustDTO>();
      }
    }
  }
}

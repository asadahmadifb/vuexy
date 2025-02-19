
using AspnetCoreMvcStarter.Models.Tsetmc;

namespace AspnetCoreMvcStarter.Services
{
  public interface ITsetmcService
  {
    public Task<List<ClosingPriceDTO>> GetClosingPricesAsync(string isnCode, int recordCount);
    public Task<List<TradeTopDTO>> GetInstrumentAsync();
    public Task<List<InstrumentShareChangeDTO>> GetInstrumentShareChangeAsync(string isnCode);
    public Task<List<PriceAdjustDTO>> GetPriceAdjustAsync(string isnCode);
  }
}

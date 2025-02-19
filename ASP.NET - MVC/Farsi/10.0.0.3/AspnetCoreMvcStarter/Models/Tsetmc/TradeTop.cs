namespace AspnetCoreMvcStarter.Models.Tsetmc
{
  public class TradeTop
  {
    public Instrument instrument { get; set; }
    public double priceChange { get; set; }
    public double priceMin { get; set; }
    public double priceMax { get; set; }
    public double priceYesterday { get; set; }
    public double priceFirst { get; set; }
    public bool last { get; set; }
    public string insCode { get; set; }
    public long dEven { get; set; }
    public double pClosing { get; set; }
    public double pDrCotVal { get; set; }
    public double zTotTran { get; set; }
    public double qTotTran5J { get; set; }
    public double qTotCap { get; set; }
  }
}

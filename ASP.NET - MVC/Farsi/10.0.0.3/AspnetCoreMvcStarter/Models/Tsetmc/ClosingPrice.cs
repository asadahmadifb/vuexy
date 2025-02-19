namespace AspnetCoreMvcStarter.Models.Tsetmc
{
  public class ClosingPrice
  {
    public double PriceChange { get; set; }
    public double PriceMin { get; set; }
    public double PriceMax { get; set; }
    public double PriceYesterday { get; set; }
    public double PriceFirst { get; set; }
    public bool Last { get; set; }
    public int Id { get; set; }
    public string InsCode { get; set; }
    public int DEven { get; set; }
    public int HEven { get; set; }
    public double PClosing { get; set; }
    public bool IClose { get; set; }
    public bool YClose { get; set; }
    public double PDrCotVal { get; set; }
    public double ZTotTran { get; set; }
    public double QTotTran5J { get; set; }
    public double QTotCap { get; set; }
  }
}

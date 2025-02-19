namespace AspnetCoreMvcStarter.Models.Tsetmc
{
  public class PriceAdjustDTO
  {
    public long InsCode { get; set; } // کد ابزار
    public int DEven { get; set; } // تاریخ به صورت عدد (YYYYMMDD)
    public double Diff { get; set; } 
    public string PersianDate { get; set; }
  }
}

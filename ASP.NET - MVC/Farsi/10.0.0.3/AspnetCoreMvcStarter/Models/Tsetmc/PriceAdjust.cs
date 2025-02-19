namespace AspnetCoreMvcStarter.Models.Tsetmc
{
  public class PriceAdjust
  {
    public long InsCode { get; set; } // کد ابزار
    public int DEven { get; set; } // تاریخ به صورت عدد (YYYYMMDD)
    public double PClosing { get; set; } // قیمت پایانی
    public double PClosingNotAdjusted { get; set; } // قیمت پایانی بدون تنظیم
    public string CorporateTypeCode { get; set; } // کد نوع شرکتی (nullable)
    public string Instrument { get; set; } // ابزار (nullable)
  }
}

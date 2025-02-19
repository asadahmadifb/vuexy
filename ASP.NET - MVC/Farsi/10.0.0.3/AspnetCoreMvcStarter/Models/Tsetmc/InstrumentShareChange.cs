namespace AspnetCoreMvcStarter.Models.Tsetmc
{
  public class InstrumentShareChange
  {
    public int Idn { get; set; } // شناسه
    public string InsCode { get; set; } // کد ابزار
    public int DEven { get; set; } // تاریخ به صورت عدد (YYYYMMDD)
    public double NumberOfShareNew { get; set; } // تعداد سهام جدید
    public double NumberOfShareOld { get; set; } // تعداد سهام قدیمی
    public double? LVal30 { get; set; } // مقدار 30 (nullable)
    public double? LVal18AFC { get; set; } // مقدار 18 AFC (nullable)
  }
}

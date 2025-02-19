namespace AspnetCoreMvcStarter.Models.Tsetmc
{
  public class InstrumentShareChangeDTO
  {
    public string InsCode { get; set; } // کد ابزار
    public int DEven { get; set; } // تاریخ به صورت عدد (YYYYMMDD)
    public double NumberOfShareNew { get; set; } // تعداد سهام جدید
    public double NumberOfShareOld { get; set; } // تعداد سهام قدیمی
    public double Diff { get; set; } // تعداد سهام قدیمی
    public string PersianDate { get; set; }

  }
}

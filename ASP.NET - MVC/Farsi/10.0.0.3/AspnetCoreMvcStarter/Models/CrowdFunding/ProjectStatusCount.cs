namespace AspnetCoreMvcStarter.Models.CrowdFunding
{
  public class ProjectStatusCount
  {
    public int ProjectStatusCode { get; set; }
    public string ProjectStatus { get; set; } // وضعیت پروژه به زبان فارسی
    public string ProjectStatusLatin { get; set; } // وضعیت پروژه به زبان لاتین
    public int ProjectCount { get; set; } // تعداد پروژه‌ها
    public decimal Percentage { get; set; } // درصد پروژه‌ها نسبت به کل

  }
}

namespace AspnetCoreMvcStarter.Models.CrowdFunding
{
  public class ProjectFinancingSummary
  {
    public string Year { get; set; } // سال شمسی
    public int TotalProjects { get; set; } // تعداد طرح‌ها
    public int TotalInvestments { get; set; } // تعداد سرمایه‌گذاری‌ها
    public int UniqueInvestors { get; set; } // تعداد سرمایه‌گذاران یونیک
    public long TotalInvestmentAmount { get; set; } // مبلغ سرمایه‌گذاری

  }
}

using OpenQA.Selenium;
using static OpenQA.Selenium.BiDi.Modules.Script.RealmInfo;

namespace AspnetCoreMvcStarter.Models.CrowdFunding
{
//  SELECT
//    YEAR(p.UnderwritingStartDate) AS[سال],
//    MONTH(p.UnderwritingStartDate) AS[ماه],
//    COUNT(p.ID) AS[تعداد طرح‌ها],
//    SUM(p.TotalPrice) AS[مجموع مبلغ مورد نیاز]
//FROM
//    dbo.Project AS p
//WHERE
//    p.UnderwritingStartDate IS NOT NULL  -- فقط طرح‌هایی که تاریخ شروع جمع آوری وجوه دارند
//GROUP BY
//    YEAR(p.UnderwritingStartDate),
//    MONTH(p.UnderwritingStartDate)
//ORDER BY
//    YEAR(p.UnderwritingStartDate),
//    MONTH(p.UnderwritingStartDate);

  public class UnderwritingByYear
  {
    public int id { get; set; }
    public int Year { get; set; }
    public int Month { get; set; }
    public int ProjectCount { get; set; }
    public Int64 TotalPrice { get; set; }
  }
}

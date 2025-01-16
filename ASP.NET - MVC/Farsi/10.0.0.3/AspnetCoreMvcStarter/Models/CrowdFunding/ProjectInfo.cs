namespace AspnetCoreMvcStarter.Models.CrowdFunding
{
//  SELECT p.ID, p.PersianName, p.TotalPrice, CASE[CrowdFundingType] WHEN 1 THEN N'همه یا هیچ' WHEN 2 THEN N'شناور' ELSE NULL END AS CrowdFundingType,
//                         CASE[ProjectStatus] WHEN 0 THEN N'نامشخص' WHEN 1 THEN N'در انتظار تایید نهاد مالی' WHEN 2 THEN N'در انتظار تایید عامل' WHEN 3 THEN N'در انتظار صدور نماد' WHEN 4 THEN N'رد طرح' WHEN 5 THEN N'آغاز جمع آوری وجوه' WHEN
//                          6 THEN N'پایان دوره جمع آوری وجوه' WHEN 7 THEN N'عدم موفقیت جمع آوری وجوه' WHEN 8 THEN N'تایید موفقیت طرح توسط عامل' WHEN 9 THEN N'تایید موفقیت طرح توسط نهاد مالی' WHEN 10 THEN N'تایید نهایی موفقیت طرح' WHEN 11 THEN
//                          N'تایید اتوماتیک طرح' WHEN 12 THEN N'عدم تایید اتوماتیک طرح' WHEN 13 THEN N'تایید موفقیت جمع آوری وجوه توسط نهاد مالی' WHEN 14 THEN N'عدم تایید موفقیت جمع آوری وجوه توسط نهاد مالی' WHEN 15 THEN N'تایید نهایی موفقیت جمع آوری وجوه'
//                          WHEN 16 THEN N'عدم تایید نهایی موفقیت جمع آوری وجوه' WHEN 17 THEN N'تعلیق' WHEN 18 THEN N'لغو' WHEN 19 THEN N'آماده سازی جمع آوری وجوه' WHEN 20 THEN N'اعلام پرداخت متقاضی طرح' WHEN 21 THEN N'اعلام پایان جمع آوری وجوه و درخواست واریز وجوه به متقاضی'
//                          ELSE NULL END AS ProjectStatus, p.UnderwritingApprovedStartDate, p.UnderwritingDuration, c.Name, plr.PlatformUrl, plr.BrokerName, p.PersianSubject, pc.Name AS CompanyName, p.PersianApprovedSymbol,
//                         p.IndustryGroupDescription, p.SubIndustryGroupDescription, p.MinimumRequiredPrice, p.RealPersonMinimumAvailablePrice, p.RealPersonMaximumAvailablePrice, p.LegalPersonMinimumAvailablePrice,
//                         p.LegalPersonMaximumAvailablePrice, p.UnderwritingStartDate, p.UnderwritingEndDate, p.ProjectStartDate, p.ProjectEndDate, p.CompanyUnitCounts, p.CommissionIfb, p.CommissionAgent, p.GuaranteeType,
//                         pc.CompanyNationalID, pc.RegistrationNumber, pc.RegistrationDate, pc.EconomicID, pc.CompanyType, pc.PostalCode
//FROM            dbo.Project AS p INNER JOIN
//                         dbo.Company AS c ON c.CompanyNationalID = p.CompanyID INNER JOIN
//                         dbo.PlatformActivityRequest AS plr ON plr.CompanyNationalID = c.CompanyNationalID INNER JOIN
//                         dbo.ProjectCompany AS pc ON pc.ProjectID = p.ID
  public class ProjectInfo
  {
    // شناسه طرح
    public int ID { get; set; }

    // نام طرح یا پروژه
    public string PersianName { get; set; }

    // مبلغ مورد نیاز
    public decimal TotalPrice { get; set; }

    // نوع تامین مالی جمعی
    public string CrowdFundingType { get; set; }

    // وضعیت طرح
    public string ProjectStatus { get; set; }

    // تاریخ تایید شده شروع جمع آوری وجوه
    public DateTime? UnderwritingApprovedStartDate { get; set; }

    // دوره جمع آوری وجوه
    public int UnderwritingDuration { get; set; }

    // نام عامل
    public string AgentName { get; set; }

    // لینک عامل
    public string PlatformUrl { get; set; }

    // نام سکو
    public string BrokerName { get; set; }

    // موضوع طرح
    public string PersianSubject { get; set; }

    // نام شرکت
    public string CompanyName { get; set; }

    // نماد طرح
    public string PersianApprovedSymbol { get; set; }

    // گروه صنعت
    public string IndustryGroupDescription { get; set; }

    // زیرگروه صنعت
    public string SubIndustryGroupDescription { get; set; }

    // حداقل مبلغ مورد نیاز جهت موفقیت تامین مالی
    public decimal MinimumRequiredPrice { get; set; }

    // حداقل مبلغ سرمایه گذاری برای تامین کننده حقیقی
    public decimal RealPersonMinimumAvailablePrice { get; set; }

    // حداکثر مبلغ سرمایه گذاری برای تامین کننده حقیقی
    public decimal RealPersonMaximumAvailablePrice { get; set; }

    // حداقل مبلغ سرمایه گذاری برای تامین کننده حقوقی
    public decimal LegalPersonMinimumAvailablePrice { get; set; }

    // حداکثر مبلغ سرمایه گذاری برای تامین کننده حقوقی
    public decimal LegalPersonMaximumAvailablePrice { get; set; }

    // تاریخ پیشنهادی شروع جمع آوری وجوه
    public DateTime? UnderwritingStartDate { get; set; }

    // تاریخ پیشنهادی پایان جمع آوری وجوه
    public DateTime? UnderwritingEndDate { get; set; }

    // تاریخ شروع پروژه
    public DateTime? ProjectStartDate { get; set; }

    // تاریخ اتمام پروژه
    public DateTime? ProjectEndDate { get; set; }

    // تعداد گواهی شراکت متقاضی
    public int CompanyUnitCounts { get; set; }

    // کارمزد فرابورس
    public decimal CommissionIfb { get; set; }

    // کارمزد عامل
    public decimal CommissionAgent { get; set; }

    // نوع وثیقه
    public string GuaranteeType { get; set; }

    // شناسه ملی
    public string CompanyNationalID { get; set; }

    // شماره ثبت شرکت
    public string RegistrationNumber { get; set; }

    // تاریخ ثبت شرکت
    public DateTime? RegistrationDate { get; set; }

    // کد اقتصادی شرکت
    public string EconomicID { get; set; }

    // نوع شخصیت حقوقی شرکت
    public string CompanyType { get; set; }

    // کد پستی شرکت
    public string PostalCode { get; set; }
  }
}

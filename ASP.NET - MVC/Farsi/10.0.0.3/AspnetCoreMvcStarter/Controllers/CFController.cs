using System.Data.Entity;
using AspnetCoreMvcStarter.Content;
using AspnetCoreMvcStarter.Data;
using AspnetCoreMvcStarter.Models;
using AspnetCoreMvcStarter.Models.CrowdFunding;
using AspnetCoreMvcStarter.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace AspnetCoreMvcStarter.Controllers
{
    //[CustomAuthorizeAttribute("09334252527")]
    public class CFController : Controller
    {
        private readonly ICrowdFundingService _CrowdFundingService;
        private readonly AspnetCoreMvcStarterContext _context;
       public CFController(ICrowdFundingService CrowdFundingService, AspnetCoreMvcStarterContext context)
        {
            _CrowdFundingService = CrowdFundingService;
            _context = context;
       }


    [HttpPost]
        public IActionResult GenerateProjects()
        {
            GenerateRandomProjects(); // متد تولید پروژه‌های تصادفی
            return RedirectToAction("Index"); // به اکشن اصلی برگردید
        }
        public void GenerateRandomProjects()
        {
          #region MyRegion

          List<Project> projects = new List<Project>
                    {
                        new Project
                        {
                            ProjectID = 1,
                            RequestDate = new DateTime(1399, 11, 20).ToString("yyyy/MM/dd"),
                            Symbol = "کبهیار",
                            PlatformName = "کارن کراد",
                            Applicant = "بهیار صنعت سپاهان",
                            NationalID = "10260423426",
                            ProjectTitle = "دستگاه رادیولوژی دیجیتال سقفی بهیار",
                            ApprovalDate = new DateTime(1400, 3, 24).ToString("yyyy/MM/dd"),
                            TotalFundingRequired = 13750000000,
                            TotalRaisedAmount = 13750000000,
                            ActualRaisedAmount = 11375000000,
                            LegalRaisedAmount = 2375000000,
                            IndividualContributorsCount = 63,
                            LegalContributorsCount = 2,
                            FundCollectionDate = new DateTime(1399, 12, 26).ToString("yyyy/MM/dd"),
                            ProjectStartDate = new DateTime(1399, 12, 27).ToString("yyyy/MM/dd"),
                            ProjectEndDate = new DateTime(1400, 4, 27).ToString("yyyy/MM/dd"),
                            Status = "تایید نهایی موفقیت جمع آوری وجوه",
                            CollateralType = "",
                            InterestRate = 137,
                            PaymentFrequency = "ماهانه",
                            FinancialInstitutionID = "123456",
                            FinancialInstitutionName = "مشاور سرمایه گذاری ارزش پرداز آریان"
                        },
                        new Project
                        {
                            ProjectID = 2,
                            RequestDate = new DateTime(1399, 12, 1).ToString("yyyy/MM/dd"),
                            Symbol = "نوآوران",
                            PlatformName = "سرمایه گذاری نوین",
                            Applicant = "شرکت نوآوران فناوری",
                            NationalID = "10260423427",
                            ProjectTitle = "سیستم هوشمند مدیریت ساختمان",
                            ApprovalDate = new DateTime(1400, 4, 10).ToString("yyyy/MM/dd"),
                            TotalFundingRequired = 25000000000,
                            TotalRaisedAmount = 20000000000,
                            ActualRaisedAmount = 15000000000,
                            LegalRaisedAmount = 5000000000,
                            IndividualContributorsCount = 45,
                            LegalContributorsCount = 5,
                            FundCollectionDate = new DateTime(1399, 12, 30).ToString("yyyy/MM/dd"),
                            ProjectStartDate = new DateTime(1400, 1, 1).ToString("yyyy/MM/dd"),
                            ProjectEndDate = new DateTime(1400, 5, 1).ToString("yyyy/MM/dd"),
                            Status = "در حال جمع آوری وجوه",
                            CollateralType = "املاک",
                            InterestRate = 120,
                            PaymentFrequency = "فصلی",
                            FinancialInstitutionID = "654321",
                            FinancialInstitutionName = "بانک توسعه تعاون"
                        },
                        new Project
                        {
                            ProjectID = 3,
                            RequestDate = new DateTime(1399, 11, 15).ToString("yyyy/MM/dd"),
                            Symbol = "پارس",
                            PlatformName = "پلتفرم مالی پارس",
                            Applicant = "شرکت پارس خودرو",
                            NationalID = "10260423428",
                            ProjectTitle = "توسعه خودروهای برقی",
                            ApprovalDate = new DateTime(1400, 3, 15).ToString("yyyy/MM/dd"),
                            TotalFundingRequired = 30000000000,
                            TotalRaisedAmount = 25000000000,
                            ActualRaisedAmount = 20000000000,
                            LegalRaisedAmount = 5000000000,
                            IndividualContributorsCount = 70,
                            LegalContributorsCount = 10,
                            FundCollectionDate = new DateTime(1399, 12, 20).ToString("yyyy/MM/dd"),
                            ProjectStartDate = new DateTime(1400, 1, 15).ToString("yyyy/MM/dd"),
                            ProjectEndDate = new DateTime(1400, 8, 15).ToString("yyyy/MM/dd"),
                            Status = "تایید نهایی",
                            CollateralType = "تجهیزات",
                            InterestRate = 130,
                            PaymentFrequency = "ماهانه",
                            FinancialInstitutionID = "789012",
                            FinancialInstitutionName = "بانک ملت"
                        },
                        new Project
                        {
                            ProjectID = 4,
                            RequestDate = new DateTime(1399, 11, 10).ToString("yyyy/MM/dd"),
                            Symbol = "توسعه",
                            PlatformName = "سرمایه گذاری آینده",
                            Applicant = "شرکت توسعه فناوری",
                            NationalID = "10260423429",
                            ProjectTitle = "پروژه تحقیق و توسعه نرم‌افزار",
                            ApprovalDate = new DateTime(1400, 2, 20).ToString("yyyy/MM/dd"),
                            TotalFundingRequired = 15000000000,
                            TotalRaisedAmount = 10000000000,
                            ActualRaisedAmount = 8000000000,
                            LegalRaisedAmount = 2000000000,
                            IndividualContributorsCount = 30,
                            LegalContributorsCount = 3,
                            FundCollectionDate = new DateTime(1399, 12, 15).ToString("yyyy/MM/dd"),
                            ProjectStartDate = new DateTime(1400, 1, 10).ToString("yyyy/MM/dd"),
                            ProjectEndDate = new DateTime(1400, 6, 10).ToString("yyyy/MM/dd"),
                            Status = "در حال جمع آوری وجوه",
                            CollateralType = "نقدی",
                            InterestRate = 125,
                            PaymentFrequency = "ماهانه",
                            FinancialInstitutionID = "345678",
                            FinancialInstitutionName = "بانک صادرات"
                        },
                        new Project
                        {
                            ProjectID = 5,
                            RequestDate = new DateTime(1399, 12, 5).ToString("yyyy/MM/dd"),
                            Symbol = "مهر",
                            PlatformName = "سرمایه گذاری مهر",
                            Applicant = "شرکت مهر صنعت",
                            NationalID = "10260423430",
                            ProjectTitle = "پروژه ساخت ماشین‌آلات صنعتی",
                            ApprovalDate = new DateTime(1400, 4, 5).ToString("yyyy/MM/dd"),
                            TotalFundingRequired = 20000000000,
                            TotalRaisedAmount = 15000000000,
                            ActualRaisedAmount = 10000000000,
                            LegalRaisedAmount = 5000000000,
                            IndividualContributorsCount = 50,
                            LegalContributorsCount = 4,
                            FundCollectionDate = new DateTime(1399, 12, 25).ToString("yyyy/MM/dd"),
                            ProjectStartDate = new DateTime(1400, 1, 20).ToString("yyyy/MM/dd"),
                            ProjectEndDate = new DateTime(1400, 7, 20).ToString("yyyy/MM/dd"),
                            Status = "تایید نهایی موفقیت جمع آوری وجوه",
                            CollateralType = "املاک",
                            InterestRate = 140,
                            PaymentFrequency = "فصلی",
                            FinancialInstitutionID = "456789",
                            FinancialInstitutionName = "بانک ملی"
                        },
                        new Project
                        {
                            ProjectID = 6,
                            RequestDate = new DateTime(1399, 11, 25).ToString("yyyy/MM/dd"),
                            Symbol = "آریا",
                            PlatformName = "سرمایه گذاری آریا",
                            Applicant = "شرکت آریا تکنولوژی",
                            NationalID = "10260423431",
                            ProjectTitle = "پروژه تحقیقاتی در حوزه هوش مصنوعی",
                            ApprovalDate = new DateTime(1400, 3, 30).ToString("yyyy/MM/dd"),
                            TotalFundingRequired = 18000000000,
                            TotalRaisedAmount = 12000000000,
                            ActualRaisedAmount = 9000000000,
                            LegalRaisedAmount = 3000000000,
                            IndividualContributorsCount = 40,
                            LegalContributorsCount = 6,
                            FundCollectionDate = new DateTime(1399, 12, 28).ToString("yyyy/MM/dd"),
                            ProjectStartDate = new DateTime(1400, 1, 5).ToString("yyyy/MM/dd"),
                            ProjectEndDate = new DateTime(1400, 5, 5).ToString("yyyy/MM/dd"),
                            Status = "در حال جمع آوری وجوه",
                            CollateralType = "تجهیزات",
                            InterestRate = 135,
                            PaymentFrequency = "ماهانه",
                            FinancialInstitutionID = "234567",
                            FinancialInstitutionName = "بانک تجارت"
                        },
                        new Project
                        {
                            ProjectID = 7,
                            RequestDate = new DateTime(1399, 12, 15).ToString("yyyy/MM/dd"),
                            Symbol = "پیشرو",
                            PlatformName = "سرمایه گذاری پیشرو",
                            Applicant = "شرکت پیشرو صنعت",
                            NationalID = "10260423432",
                            ProjectTitle = "پروژه توسعه و نوسازی کارخانه",
                            ApprovalDate = new DateTime(1400, 4, 15).ToString("yyyy/MM/dd"),
                            TotalFundingRequired = 22000000000,
                            TotalRaisedAmount = 17000000000,
                            ActualRaisedAmount = 12000000000,
                            LegalRaisedAmount = 5000000000,
                            IndividualContributorsCount = 55,
                            LegalContributorsCount = 3,
                            FundCollectionDate = new DateTime(1399, 12, 20).ToString("yyyy/MM/dd"),
                            ProjectStartDate = new DateTime(1400, 1, 15).ToString("yyyy/MM/dd"),
                            ProjectEndDate = new DateTime(1400, 8, 15).ToString("yyyy/MM/dd"),
                            Status = "تایید نهایی",
                            CollateralType = "نقدی",
                            InterestRate = 130,
                            PaymentFrequency = "فصلی",
                            FinancialInstitutionID = "678901",
                            FinancialInstitutionName = "بانک سامان"
                        },
                        new Project
                        {
                            ProjectID = 8,
                            RequestDate = new DateTime(1399, 12, 10).ToString("yyyy/MM/dd"),
                            Symbol = "توسعه پایدار",
                            PlatformName = "سرمایه گذاری پایدار",
                            Applicant = "شرکت توسعه پایدار",
                            NationalID = "10260423433",
                            ProjectTitle = "پروژه انرژی‌های تجدیدپذیر",
                            ApprovalDate = new DateTime(1400, 3, 5).ToString("yyyy/MM/dd"),
                            TotalFundingRequired = 24000000000,
                            TotalRaisedAmount = 20000000000,
                            ActualRaisedAmount = 15000000000,
                            LegalRaisedAmount = 5000000000,
                            IndividualContributorsCount = 65,
                            LegalContributorsCount = 7,
                            FundCollectionDate = new DateTime(1399, 12, 25).ToString("yyyy/MM/dd"),
                            ProjectStartDate = new DateTime(1400, 1, 25).ToString("yyyy/MM/dd"),
                            ProjectEndDate = new DateTime(1400, 9, 25).ToString("yyyy/MM/dd"),
                            Status = "در حال جمع آوری وجوه",
                            CollateralType = "املاک",
                            InterestRate = 145,
                            PaymentFrequency = "ماهانه",
                            FinancialInstitutionID = "789012",
                            FinancialInstitutionName = "بانک پارسیان"
                        },
                        new Project
                        {
                            ProjectID = 9,
                            RequestDate = new DateTime(1399, 11, 30).ToString("yyyy/MM/dd"),
                            Symbol = "فناوری نوین",
                            PlatformName = "پلتفرم سرمایه گذاری نوین",
                            Applicant = "شرکت فناوری نوین",
                            NationalID = "10260423434",
                            ProjectTitle = "پروژه توسعه نرم‌افزارهای مالی",
                            ApprovalDate = new DateTime(1400, 4, 20).ToString("yyyy/MM/dd"),
                            TotalFundingRequired = 21000000000,
                            TotalRaisedAmount = 16000000000,
                            ActualRaisedAmount = 11000000000,
                            LegalRaisedAmount = 5000000000,
                            IndividualContributorsCount = 50,
                            LegalContributorsCount = 2,
                            FundCollectionDate = new DateTime(1399, 12, 18).ToString("yyyy/MM/dd"),
                            ProjectStartDate = new DateTime(1400, 1, 30).ToString("yyyy/MM/dd"),
                            ProjectEndDate = new DateTime(1400, 6, 30).ToString("yyyy/MM/dd"),
                            Status = "تایید نهایی موفقیت جمع آوری وجوه",
                            CollateralType = "تجهیزات",
                            InterestRate = 150,
                            PaymentFrequency = "فصلی",
                            FinancialInstitutionID = "890123",
                            FinancialInstitutionName = "بانک قرض الحسنه مهر ایران"
                        },
                        new Project
                        {
                            ProjectID = 10,
                            RequestDate = new DateTime(1399, 12, 20).ToString("yyyy/MM/dd"),
                            Symbol = "نوآوری",
                            PlatformName = "پلتفرم نوآوری",
                            Applicant = "شرکت نوآوری و فناوری",
                            NationalID = "10260423435",
                            ProjectTitle = "پروژه توسعه فناوری‌های نوین",
                            ApprovalDate = new DateTime(1400, 5, 10).ToString("yyyy/MM/dd"),
                            TotalFundingRequired = 30000000000,
                            TotalRaisedAmount = 25000000000,
                            ActualRaisedAmount = 20000000000,
                            LegalRaisedAmount = 5000000000,
                            IndividualContributorsCount = 75,
                            LegalContributorsCount = 8,
                            FundCollectionDate = new DateTime(1400, 1, 5).ToString("yyyy/MM/dd"),
                            ProjectStartDate = new DateTime(1400, 2, 1).ToString("yyyy/MM/dd"),
                            ProjectEndDate = new DateTime(1400, 7, 1).ToString("yyyy/MM/dd"),
                            Status = "در حال جمع آوری وجوه",
                            CollateralType = "نقدی",
                            InterestRate = 155,
                            PaymentFrequency = "ماهانه",
                            FinancialInstitutionID = "901234",
                            FinancialInstitutionName = "بانک دی"
                        }
                    };

          #endregion
          var existingProjects = _context.Projects.ToList(); // دریافت تمام پروژه‌ها
          _context.Projects.RemoveRange(existingProjects); // حذف تمام پروژه‌ها
          _context.SaveChanges(); // ذخیره تغییرات در پایگاه داده
          _context.Projects.AddRange(projects);
          _context.SaveChanges();
        }
        public async Task<IActionResult> Index()
            {
                ProjectAi projectAi=new ProjectAi();
                var projectsnew =await _CrowdFundingService.GetProjects();
                projectAi.projects = projectsnew;
           
                return View(projectAi);
            }
        public async Task<JsonResult> deletehistory()
        {
          // داده‌ها را از منبع داده (مثلاً پایگاه داده) دریافت کنید
          //var examples = new List<string>
          //  {
          //      "نام 5 طرح برتر",
          //      "جمع کل مبلغ سرمایه گذاری",
          //      "مجموع حقیقی و حقوقی کل طرحها"
          //  };
          var questionHistories = _context.QuestionHistories.ToList();
          _context.QuestionHistories.RemoveRange(questionHistories);
          _context.SaveChanges();
          questionHistories = _context.QuestionHistories.ToList();

          // ایجاد لیست برای ذخیره نتایج
          var examples = new List<object>();
          // داده‌ها را به فرمت JSON برمی‌گرداند
          return Json(examples);
        }
    // اکشن برای حذف آیتم چت




  }
}

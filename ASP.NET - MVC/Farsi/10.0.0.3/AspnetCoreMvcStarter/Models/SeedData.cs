using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using AspnetCoreMvcStarter.Data;
using AspnetCoreMvcStarter.Models.CrowdFunding;

namespace AspnetCoreMvcStarter.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AspnetCoreMvcStarterContext(
                serviceProvider.GetRequiredService<DbContextOptions<AspnetCoreMvcStarterContext>>()))
            {
                if (context == null || context.Transactions == null)
                {
                    throw new ArgumentNullException("Null AspnetCoreMvcStarterContext");
                }

                // Look for any transactions.
                if (!context.Transactions.Any())
                {
                  context.Transactions.AddRange(
                new Transactions
                {
                  Customer = "نوید محمدزاده",
                  TransactionDate = DateTime.Parse("1402-01-01"),
                  DueDate = DateTime.Parse("1402-01-10"),
                  Total = 100.50m,
                  Status = "paid"
                },
                new Transactions
                {
                  Customer = "سارا اعتمادی",
                  TransactionDate = DateTime.Parse("1402-02-15"),
                  DueDate = DateTime.Parse("1402-02-28"),
                  Total = 75.20m,
                  Status = "due"
                },
                new Transactions
                {
                  Customer = "ساعد سهیلی",
                  TransactionDate = DateTime.Parse("1402-03-10"),
                  DueDate = DateTime.Parse("1402-03-15"),
                  Total = 50.75m,
                  Status = "canceled"
                },
                new Transactions
                {
                  Customer = "پارسا پیروزفر",
                  TransactionDate = DateTime.Parse("1402-03-11"),
                  DueDate = DateTime.Parse("1402-03-25"),
                  Total = 90.65m,
                  Status = "due"
                },
                new Transactions
                {
                  Customer = "اتنا طهماسبی",
                  TransactionDate = DateTime.Parse("1402-05-10"),
                  DueDate = DateTime.Parse("1402-07-15"),
                  Total = 60.25m,
                  Status = "paid"
                }
            );
                }

              

                if (!context.Orders.Any())
                {
                  context.Orders.AddRange(
                    new Order { Id = 1, ProjectName = "وتامین", Benefit = "41%", StartTime = "10:23", Amount = "1000", Pay = "296" , Status=0 },
                    new Order { Id = 2, ProjectName = "آب و انرژی", Benefit = "35%", StartTime = "11:15", Amount = "2000", Pay = "450", Status = 0 }

                    );
                }

        if (!context.ProjectViews.Any())
        {
          context.ProjectViews.AddRange(
         new ProjectView
         {
           شناسه_طرح = 47,
           نام_طرح_یا_پروژه = "دستگاه شتابدهنده خطی پزشکی",
           مبلغ_مورد_نیاز = 37000000000,
           نوع_تامین_مالی_جمعی = "همه یا هیچ",
           وضعیت_طرح = "تایید نهایی موفقیت جمع آوری وجوه",
           تاریخ_تایید_شده_شروع_جمع_آوری_وجوه = DateTime.Parse("2022-02-15 00:00:00.000"),
           دوره_جمع_آوری_وجوه = 30,
           نام_عامل = "گروه پیشگامان کارآفرینی کارن",
           لینک_عامل = "https://www.karencrowd.com/home.html",
           موضوع_طرح = "شرکت دانش‌بنیان بهیار صنعت سپاهان برای اولین بار در کشور، موفق به طراحی و ساخت دستگاه شتابدهنده خطی پزشکی درمان سرطان با بالاترین درصد بومی‌سازی در کشور و چهارمین در دنیا شده است و ایران به این واسطه به جمع چند کشور محدود دارای این فناوری پیوسته است.",
           نام_شرکت = "بهیار صنعت سپاهان",
           نام_سکو= "مشاور سرمایه گذاری ارزش پرداز آریان",
           نماد_طرح = "کاربهیار",
           گروه_صنعت = "ابزارپزشکی، اپتیکی و اندازه‌گیری",
           زیرگروه_صنعت = "وسایل اندازه گیری غیر از کنترل صنعتی",
           حداقل_مبلغ_مورد_نیاز_جهت_موفقیت_تامین_مالی = 0,
           حداقل_مبلغ_سرمایه_گذاری_برای_تامین_کننده_حقیقی = 5000000,
           حداکثر_مبلغ_سرمایه_گذاری_برای_تامین_کننده_حقیقی = 1850000000,
           حداقل_مبلغ_سرمایه_گذاری_برای_تامین_کننده_حقوقی = 5000000,
           حداکثر_مبلغ_سرمایه_گذاری_برای_تامین_کننده_حقوقی = 37000000000,
           تاریخ_پیشنهادی_شروع_جمع_آوری_وجوه = DateTime.Parse("2022-02-15 00:00:00.000"),
           تاریخ_پیشنهادی_پایان_جمع_آوری_وجوه = DateTime.Parse("2022-03-17 00:00:00.000"),
           تاریخ_شروع_پروژه = DateTime.Parse("2022-03-18 00:00:00.000"),
           تاریخ_اتمام_پروژه = DateTime.Parse("2022-10-01 00:00:00.000"),
           تعداد_گواهی_شراکت_متقاضی = 3700000,
           کارمزد_فرابورس = 50000000,
           کارمزد_عامل = 720000000,
           نوع_وثیقه = "املاک",
           شناسه_ملی = "10260423426",
           شماره_ثبت_شرکت = "1144",
           تاریخ_ثبت_شرکت = DateTime.Parse("2003-12-13 00:00:00.000"),
           کد_اقتصادی_شرکت = "411171689657",
           نوع_شخصیت_حقوقی_شرکت = "2",
           کد_پستی_شرکت = "8415683121"
         },
            new ProjectView
            {
              شناسه_طرح = 48,
              نام_طرح_یا_پروژه = "کیت مولکولی تشخیص ویروس کرونا",
              مبلغ_مورد_نیاز = 10000000000,
              نوع_تامین_مالی_جمعی = "همه یا هیچ",
              وضعیت_طرح = "تایید نهایی موفقیت جمع آوری وجوه",
              تاریخ_تایید_شده_شروع_جمع_آوری_وجوه = DateTime.Parse("2022-02-14 00:00:00.000"),
              دوره_جمع_آوری_وجوه = 30,
              نام_عامل = "گروه پیشگامان کارآفرینی کارن",
              لینک_عامل = "https://www.karencrowd.com/home.html",
              موضوع_طرح = "همزمان با همه‌گیری ویروس کرونا، مهم‌ترین امر جهت پیشگیری از گسترش این ویروس، تشخیص این بیماری است. شرکت توپازژن کاوش با بهره‌گیری از به‌روزترین فناوری‌های تولید، اقدام به ساخت کیت تشخیص مولکولی کرونا به روش RT-PCR کرده است.",
              نام_شرکت = "توپاز ژن کاوش",
              نام_سکو = "مشاور سرمایه گذاری ارزش پرداز آریان",
              نماد_طرح = "کتوپازژن",
              گروه_صنعت = "ابزارپزشکی، اپتیکی و اندازه‌گیری",
              زیرگروه_صنعت = "وسایل اندازه گیری غیر از کنترل صنعتی",
              حداقل_مبلغ_مورد_نیاز_جهت_موفقیت_تامین_مالی = 0,
              حداقل_مبلغ_سرمایه_گذاری_برای_تامین_کننده_حقیقی = 5000000,
              حداکثر_مبلغ_سرمایه_گذاری_برای_تامین_کننده_حقیقی = 500000000,
              حداقل_مبلغ_سرمایه_گذاری_برای_تامین_کننده_حقوقی = 5000000,
              حداکثر_مبلغ_سرمایه_گذاری_برای_تامین_کننده_حقوقی = 10000000000,
              تاریخ_پیشنهادی_شروع_جمع_آوری_وجوه = DateTime.Parse("2022-02-14 00:00:00.000"),
              تاریخ_پیشنهادی_پایان_جمع_آوری_وجوه = DateTime.Parse("2022-03-16 00:00:00.000"),
              تاریخ_شروع_پروژه = DateTime.Parse("2022-03-17 00:00:00.000"),
              تاریخ_اتمام_پروژه = DateTime.Parse("2022-09-30 00:00:00.000"),
              تعداد_گواهی_شراکت_متقاضی = 1000000,
              کارمزد_فرابورس = 50000000,
              کارمزد_عامل = 400000000,
              نوع_وثیقه = "چک",
              شناسه_ملی = "10320811085",
              شماره_ثبت_شرکت = "26605",
              تاریخ_ثبت_شرکت = DateTime.Parse("2012-08-05 00:00:00.000"),
              کد_اقتصادی_شرکت = "411455146684",
              نوع_شخصیت_حقوقی_شرکت = "2",
              کد_پستی_شرکت = "3197996737"
            },
            new ProjectView
            {
              شناسه_طرح = 49,
              نام_طرح_یا_پروژه = "تجارت کالاهای مصرفی آریسا",
              مبلغ_مورد_نیاز = 19950000000,
              نوع_تامین_مالی_جمعی = "شناور",
              وضعیت_طرح = "تایید نهایی موفقیت جمع آوری وجوه",
              تاریخ_تایید_شده_شروع_جمع_آوری_وجوه = DateTime.Parse("2022-02-14 00:00:00.000"),
              دوره_جمع_آوری_وجوه = 27,
              نام_سکو = "سبدگردان الگوريتم",
              نام_عامل = "سامانه نگار آتنا",
              لینک_عامل = "dongi.ir",
              موضوع_طرح = "شرکت تجارت گستر آریسا تامین کننده کالای مصرفی برای سازمان‌های دولتی و نهادهای عمومی است.",
              نام_شرکت = "تجارت گستر آریسا",
              نماد_طرح = "دآریساتگ",
              گروه_صنعت = "تجارت عمده فروشی به جز وسایل نقلیه موتور",
              زیرگروه_صنعت = "عمده فروشی براساس هزینه و یا قرارداد",
              حداقل_مبلغ_مورد_نیاز_جهت_موفقیت_تامین_مالی = 10000000000,
              حداقل_مبلغ_سرمایه_گذاری_برای_تامین_کننده_حقیقی = 5000000,
              حداکثر_مبلغ_سرمایه_گذاری_برای_تامین_کننده_حقیقی = 997500000,
              حداقل_مبلغ_سرمایه_گذاری_برای_تامین_کننده_حقوقی = 50000000,
              حداکثر_مبلغ_سرمایه_گذاری_برای_تامین_کننده_حقوقی = 19950000000,
              تاریخ_پیشنهادی_شروع_جمع_آوری_وجوه = DateTime.Parse("2022-02-14 00:00:00.000"),
              تاریخ_پیشنهادی_پایان_جمع_آوری_وجوه = DateTime.Parse("2022-03-06 00:00:00.000"),
              تاریخ_شروع_پروژه = DateTime.Parse("2022-03-08 00:00:00.000"),
              تاریخ_اتمام_پروژه = DateTime.Parse("2023-03-08 00:00:00.000"),
              تعداد_گواهی_شراکت_متقاضی = 1995000,
              کارمزد_فرابورس = 50000000,
              کارمزد_عامل = 720000000,
              نوع_وثیقه = "سفته",
              شناسه_ملی = "14004650384",
              شماره_ثبت_شرکت = "465872",
              تاریخ_ثبت_شرکت = DateTime.Parse("2014-12-31 00:00:00.000"),
              کد_اقتصادی_شرکت = "411513714591",
              نوع_شخصیت_حقوقی_شرکت = "2",
              کد_پستی_شرکت = "1389794381",
              
            });
        }

        if (!context.ProjectInfos.Any())
        {
          context.ProjectInfos.AddRange(
            new ProjectInfo
            {
              ID = 687,
              PersianName = "تامین سرمایه در گردش لازم جهت پروژه تأسیسات مکانیکی بهشتی فاز1",
              TotalPrice = 120000000000,
              CrowdFundingType = "شناور",
              ProjectStatus = "در انتظار صدور نماد",
              UnderwritingApprovedStartDate = DateTime.Parse("2024-06-05"),
              UnderwritingDuration = 30,
              AgentName = "مشاورسرمایه گذاری فراز ایده نوآفرین تک (فاینتک)",
              PlatformUrl = "hamafarin.ir",
              BrokerName = "مشاور سرمایه گذاری فراز ایده نوآفرین تک",
              PersianSubject = "شرکت شرق سازه کویر جهت طرح تامین سرمایه در گردش لازم جهت پروژه تأسیسات مکانیکی بهشتی فاز1 ، اقدام به انجام تامین مالی از طریق سکوی هم آفرین نموده است. این طرح  12 ماهه می باشد و خدمات این شرکت مطابق قرارداد به وکالت از سرمایه‌گذار ، در بازار ارائه میگردد. شرکت شرق سازه کویر اقدام به انجام تامین مالی از طریق سکوی تامین مالی هم آفرین به مبلغ 12 میلیارد ریال می‌نماید و همچنین پیش بینی بازدهی این طرح برای سرمایه گذار، 40.5 درصد علی الحساب سالانه خواهد بود. متقاضی متعهد به واریز سود و اصل سرمایه در موعدهای مقرر طبق پیوست قرارداد به حساب عامل جهت واریز به حساب سرمایه گذاران است. به منظور شروع و اجرایی شدن جمع آوری وجوه، متقاضی ضمانت نامه تعهد پرداخت بانک ملی و چک شرکت، بعنوان تضامین طرح به عامل ارائه نموده است. جزییات این وثایق در قرارداد سرمایه گذار و متقاضی منعکس گردیده است.",
              CompanyName = "شرق سازه کویر",
              PersianApprovedSymbol = "همآفرشرق",
              IndustryGroupDescription = "پیمانکاری صنعتی",
              SubIndustryGroupDescription = "ساختمان و مهندسی عمران",
              MinimumRequiredPrice = 20000000000,
              RealPersonMinimumAvailablePrice = 1000000,
              RealPersonMaximumAvailablePrice = 6000000000,
              LegalPersonMinimumAvailablePrice = 1000000,
              LegalPersonMaximumAvailablePrice = 120000000000,
              UnderwritingStartDate = DateTime.Parse("2024-06-05"),
              UnderwritingEndDate = DateTime.Parse("2024-07-05"),
              ProjectStartDate = DateTime.Parse("2024-07-06"),
              ProjectEndDate = DateTime.Parse("2025-07-07"),
              CompanyUnitCounts = 12000000,
              CommissionIfb = 200000000,
              CommissionAgent = 3000000000,
              GuaranteeType = "1",
              CompanyNationalID = "10500055936",
              RegistrationNumber = "2018",
              RegistrationDate = DateTime.Parse("2001-07-22"),
              EconomicID = "411179394945",
              CompanyType = "2",
              PostalCode = "9816618334"
            },
            new ProjectInfo
            {
              ID = 688,
              PersianName = "تأمین سرمایه در گردش جهت تولید و فروش الکتروموتور پمپ",
              TotalPrice = 75000000000,
              CrowdFundingType = "شناور",
              ProjectStatus = "پایان دوره جمع آوری وجوه",
              UnderwritingApprovedStartDate = DateTime.Parse("2024-06-01"),
              UnderwritingDuration = 3,
              AgentName = "حساب یاری امین ملل",
              PlatformUrl = "https://halalfund.ir/",
              BrokerName = "سبدگردان الگوریتم",
              PersianSubject = "شرکت آناهیتا پمپ کاشان با استفاده از تجربه خود در صنعت ساخت انواع الکتروموتور و پمپ‌های آب و باتوجه به نیاز مشتری اقدام به ساخت این نوع الکتروموتور برای پمپ‌های آب نموده است. الکتروموتور و پمپ دو دستگاه مکانیکی هستند که در بسیاری از صنایع و کاربردهای روزمره مورد استفاده قرار می‌گیرند. هر دو دستگاه از انرژی الکتریکی برای تولید حرکت استفاده می‌کنند. الکتروموتور یک دستگاه الکترومکانیکی است که انرژی الکتریکی را به انرژی مکانیکی تبدیل می‌کند. از این‌رو شرکت آناهیتا پمپ کاشان قصد دارد جهت تأمین بخشی از سرمایه در گردش خود به میزان 75,000 میلیون ریال به منظور خرید تجهیزات در جهت تولید الکتروموتور 8 اینچ از روش تأمین مالی جمعی از طریق سکوی حلال‌فاند استفاده نماید. بر این اساس این طرح 12 ماهه بوده و طبق اظهارات متقاضی برآورد می‌شود در این مدت از طریق تولید و فروش الکتروموتور به تعداد 89 دستگاه و میانگین قیمت هر دستگاه 1,510 میلیون ریال، به میزان 134,390 میلیون ریال حاصل شود.",
              CompanyName = "آناهیتا پمپ کاشان",
              PersianApprovedSymbol = "حلالپمپک",
              IndustryGroupDescription = "ماشین آلات و تجهیزات",
              SubIndustryGroupDescription = "تولید پمپ، کمپرسور، مته و دریچه",
              MinimumRequiredPrice = 35000000000,
              RealPersonMinimumAvailablePrice = 1000000,
              RealPersonMaximumAvailablePrice = 3750000000,
              LegalPersonMinimumAvailablePrice = 100000000,
              LegalPersonMaximumAvailablePrice = 75000000000,
              UnderwritingStartDate = DateTime.Parse("2024-06-02"),
              UnderwritingEndDate = DateTime.Parse("2024-06-05"),
              ProjectStartDate = DateTime.Parse("2024-06-08"),
              ProjectEndDate = DateTime.Parse("2025-06-09"),
              CompanyUnitCounts = 7500000,
              CommissionIfb = 200000000,
              CommissionAgent = 3000000000,
              GuaranteeType = "2",
              CompanyNationalID = "14009581800",
              RegistrationNumber = "579884",
              RegistrationDate = DateTime.Parse("2020-11-14"),
              EconomicID = "14009581800",
              CompanyType = "2",
              PostalCode = "8717788391"
            },
            new ProjectInfo
            {
              ID = 689,
              PersianName = "تامین سرمایه در گردش شرکت تولیدی و بازرگانی اشجع باطری جهت تولید و فروش انواع باتری (انباره‌های سرب اسید استارتی)",
              TotalPrice = 250000000000,
              CrowdFundingType = "شناور",
              ProjectStatus = "پایان دوره جمع آوری وجوه",
              UnderwritingApprovedStartDate = DateTime.Parse("2024-05-29"),
              UnderwritingDuration = 14,
              AgentName = "شرکت تأمین‌سرمایه تمدن",
              PlatformUrl = "www.ibcrowd.ir",
              BrokerName = "تامین سرمایه تمدن",
              PersianSubject = "تاسیس شرکت تولیدی و بازرگانی اشجع باطری (سهامی خاص) به شماره ثبت 9260 به شناسه ملی 10240117985 در اداره ثبت شرکت‌ها و مؤسسات غیرتجاری اردبیل مورخ 07/07/1389 به ثبت رسیده است. نشانی مرکز اصلی شرکت در استان اردبيل،  شهرستان اردبيل،  بخش مركزی،  شهر اردبيل، محله شهرك صنعتي 2، خيابان 16متري، كوچه شهرك صنعتي، پلاك 381، طبقه همکف واقع شده است. فعالیت این شرکت تهیه و تولید انواع باتری و صادرات و فروش آنها می¬باشد. در آمد عملیاتی شرکت در سال 1401 برابر 12,517,720 میلیون ریال بوده است که نسبت به سال 1400 پیش رفت چشمگیری داشته است. از انواع محصولات این شرکت می توان به باتری های یو پی اس(انباره های سرب اسید ساکن و صنعتی) و باتری با انباره های سرب اسید استارتی که هرکدام به ترتیب فروشی برابر 2,151,300 و 10,169,345 میلیون ریال بر اساس صورت مالی حسابرسی شده 1401 داشته اند، اشاره کرد. این شرکت در نظر دارد به منظور تامین بخشی از تامین سرمایه در گردش خود به منظور تولید و فروش باتری  ، مبلغ 250 میلیارد ریال را طی یک دوره یکساله از طریق سکوی تامین مالی جمعی آی بی کراد با پرداخت سود مشارکت سالیانه 34 درصد تامین مالی نماید. جهت تضمین گواهی‌های شراکت اين طرح، متقاضی نسبت به ارائه ضمانت‌نامه تعهد پرداخت بانکی اقدام نموده است.",
              CompanyName = "تولیدی و بازرگانی اشجع باطری",
              PersianApprovedSymbol = "آیبیاتری",
              IndustryGroupDescription = "خودرو و ساخت قطعات",
              SubIndustryGroupDescription = "قطعات یدکی و جانبی وسایل نقلیه موتوری",
              MinimumRequiredPrice = 125000000000,
              RealPersonMinimumAvailablePrice = 100000000,
              RealPersonMaximumAvailablePrice = 12500000000,
              LegalPersonMinimumAvailablePrice = 100000000,
              LegalPersonMaximumAvailablePrice = 225000000000,
              UnderwritingStartDate = DateTime.Parse("2024-05-29"),
              UnderwritingEndDate = DateTime.Parse("2024-06-12"),
              ProjectStartDate = DateTime.Parse("2024-06-13"),
              ProjectEndDate = DateTime.Parse("2025-06-13"),
              CompanyUnitCounts = 25000000,
              CommissionIfb = 200000000,
              CommissionAgent = 3000000000,
              GuaranteeType = "1",
              CompanyNationalID = "10240117985",
              RegistrationNumber = "9260",
              RegistrationDate = DateTime.Parse("2010-09-29"),
              EconomicID = "411393169498",
              CompanyType = "2",
              PostalCode = "5618147787"
            },
            new ProjectInfo
            {
              ID = 690,
              PersianName = "تامین سرمایه در گردش تولید بسته مواد افزودنی",
              TotalPrice = 33500000000,
              CrowdFundingType = "شناور",
              ProjectStatus = "در انتظار تایید نهاد مالی",
              UnderwritingApprovedStartDate = DateTime.Parse("2024-06-05"),
              UnderwritingDuration = 10,
              AgentName = "سامانه تامین هوشمند نوآفرینان ایرانیان",
              PlatformUrl = "https://ifund.ir/",
              BrokerName = "سبدگردان الگوريتم",
              PersianSubject = "شرکت مهندسی همگام صنعت صدر سپاهان در نظر دارد 70،320 کیلوگرم از محصول مورد نظر را در مدت 12 ماه تولید و به فروش برساند. با توجه به سوابق شرکت و دوره گردش وصول مطالبات، دوره گردش تولید و فروش محصولات در این طرح هر 3 ماه یکبار برآورد گردیده است. بنابرین پیش بینی می شود هر سه ماه یکبار 17،850 کیلوگرم از بسته های مواد افزودنی روانکارها را تولید و به فروش برساند. بر اساس اظهارات متقاضی هزینه خرید مواد اولیه به ازای هر کیلوگرم بسته افزودنی روانکارها بطور میانگین برابر با 1،905،600 ریال پیش بینی شده که مجموع هزینه خرید مواد اولیه برای تولید 17،850 کیلوگرم بسته های افزودنی روانکارها در دوره گردش 3 ماهه، 33،500،000،000 ریال برآورد می شود. در مجموع دوره 12 ماهه هزینه خرید مواد اولیه تولید 70،320 کیلوگرم محصول برابر با 134،001،792،000ریال برآورد می‌گردد. بر اساس آخرین فاکتورهای فروش ارائه شده توسط متقاضی برآورد فروش این محصول بطور میانگین به ازای هر کیلوگرم 2،562،500 ریال می‏باشد. در مجموع فروش 17،580 کیلوگرم در دوره 3 ماهه  45,048,147,565 ریال و در دوره 12 ماهه با فروش مجموع 70،320 کیلوگرم محصول 180,195,000,000 ریال برآورد می‌گردد. سود تعریف شده  در دوره 12 ماهه طرح با کسر کارمزدهای تامین مالی جمعی میزان 44,685,708,000 ریال برآورد می‌گردد. سهم سرمایه گذاران از سود برآورد شده، 34.49 درصد بوده که مبلغ 15,410,000,000ریال می باشد که برابر با 46 درصد مبلغ طرح است.",
              CompanyName = "مهندسی همگام صنعت صدر سپاهان",
              PersianApprovedSymbol = "فاندصنعت",
              IndustryGroupDescription = "محصولات شیمیایی",
              SubIndustryGroupDescription = "تولید سایر محصولات شیمیایی",
              MinimumRequiredPrice = 10000000000,
              RealPersonMinimumAvailablePrice = 1000000,
              RealPersonMaximumAvailablePrice = 1675000000,
              LegalPersonMinimumAvailablePrice = 10000000,
              LegalPersonMaximumAvailablePrice = 33500000000,
              UnderwritingStartDate = DateTime.Parse("2024-06-05"),
              UnderwritingEndDate = DateTime.Parse("2024-06-15"),
              ProjectStartDate = DateTime.Parse("2024-06-16"),
              ProjectEndDate = DateTime.Parse("2025-06-17"),
              CompanyUnitCounts = 3350000,
              CommissionIfb = 167500000,
              CommissionAgent = 1340000000,
              GuaranteeType = "2",
              CompanyNationalID = "10260592200",
              RegistrationNumber = "1282",
              RegistrationDate = DateTime.Parse("2014-07-03"),
              EconomicID = "411373637951",
              CompanyType = "2",
              PostalCode = "8415683397"
            }
            );
        }

        if (!context.UnderwritingByYears.Any())
        {
          context.UnderwritingByYears.AddRange(
            new UnderwritingByYear { Year = 1400, Month = 1, ProjectCount = 1, TotalPrice = 10000000000 },
            new UnderwritingByYear { Year = 1400, Month = 2, ProjectCount = 2, TotalPrice = 32750000000 },
            new UnderwritingByYear { Year = 1400, Month = 4, ProjectCount = 1, TotalPrice = 10000000000 },
            new UnderwritingByYear { Year = 1400, Month = 5, ProjectCount = 1, TotalPrice = 19000000000 },
            new UnderwritingByYear { Year = 1400, Month = 7, ProjectCount = 1, TotalPrice = 13857903000 },
            new UnderwritingByYear { Year = 1400, Month = 9, ProjectCount = 3, TotalPrice = 71000000000 },
            new UnderwritingByYear { Year = 1400, Month = 10, ProjectCount = 2, TotalPrice = 37951000000 },
            new UnderwritingByYear { Year = 1400, Month = 11, ProjectCount = 4, TotalPrice = 112550000000 },
            new UnderwritingByYear { Year = 1400, Month = 12, ProjectCount = 8, TotalPrice = 197442700000 },
            new UnderwritingByYear { Year = 1401, Month = 1, ProjectCount = 12, TotalPrice = 367558500000 },
            new UnderwritingByYear { Year = 1401, Month = 2, ProjectCount = 8, TotalPrice = 148160000000 },
            new UnderwritingByYear { Year = 1401, Month = 3, ProjectCount = 7, TotalPrice = 173500000000 },
            new UnderwritingByYear { Year = 1401, Month = 4, ProjectCount = 8, TotalPrice = 224970000000 },
            new UnderwritingByYear { Year = 1401, Month = 5, ProjectCount = 10, TotalPrice = 375546000000 },
            new UnderwritingByYear { Year = 1401, Month = 6, ProjectCount = 6, TotalPrice = 268505000000 },
            new UnderwritingByYear { Year = 1401, Month = 7, ProjectCount = 10, TotalPrice = 256866000000 },
            new UnderwritingByYear { Year = 1401, Month = 8, ProjectCount = 10, TotalPrice = 464803000000 },
            new UnderwritingByYear { Year = 1401, Month = 9, ProjectCount = 7, TotalPrice = 763748000000 },
            new UnderwritingByYear { Year = 1401, Month = 10, ProjectCount = 12, TotalPrice = 573308000000 },
            new UnderwritingByYear { Year = 1401, Month = 11, ProjectCount = 17, TotalPrice = 727800000000 },
            new UnderwritingByYear { Year = 1401, Month = 12, ProjectCount = 13, TotalPrice = 531669000000 },
            new UnderwritingByYear { Year = 1402, Month = 1, ProjectCount = 11, TotalPrice = 845086000000 },
            new UnderwritingByYear { Year = 1402, Month = 2, ProjectCount = 11, TotalPrice = 1158000000000 },
            new UnderwritingByYear { Year = 1402, Month = 3, ProjectCount = 14, TotalPrice = 1745214000000 },
            new UnderwritingByYear { Year = 1402, Month = 4, ProjectCount = 10, TotalPrice = 814000000000 },
            new UnderwritingByYear { Year = 1402, Month = 5, ProjectCount = 24, TotalPrice = 2496548000000 },
            new UnderwritingByYear { Year = 1402, Month = 6, ProjectCount = 16, TotalPrice = 1822395000000 },
            new UnderwritingByYear { Year = 1402, Month = 7, ProjectCount = 15, TotalPrice = 1742935000000 },
            new UnderwritingByYear { Year = 1402, Month = 8, ProjectCount = 25, TotalPrice = 3174380000000 },
            new UnderwritingByYear { Year = 1402, Month = 9, ProjectCount = 19, TotalPrice = 2454952045000 },
            new UnderwritingByYear { Year = 1402, Month = 10, ProjectCount = 49, TotalPrice = 6195320000000 },
            new UnderwritingByYear { Year = 1402, Month = 11, ProjectCount = 25, TotalPrice = 3270500000000 },
            new UnderwritingByYear { Year = 1402, Month = 12, ProjectCount = 54, TotalPrice = 5054507000000 },
            new UnderwritingByYear { Year = 1403, Month = 1, ProjectCount = 51, TotalPrice = 5979948000000 },
            new UnderwritingByYear { Year = 1403, Month = 2, ProjectCount = 52, TotalPrice = 5978390000000 },
            new UnderwritingByYear { Year = 1403, Month = 3, ProjectCount = 61, TotalPrice = 8008810000000 },
            new UnderwritingByYear { Year = 1403, Month = 4, ProjectCount = 35, TotalPrice = 4477050000000 },
            new UnderwritingByYear { Year = 1403, Month = 5, ProjectCount = 47, TotalPrice = 5695650000000 },
            new UnderwritingByYear { Year = 1403, Month = 6, ProjectCount = 11, TotalPrice = 1420500000000 }

            );
        }

        context.SaveChanges();
            }
        }
    }
}

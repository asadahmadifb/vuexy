namespace AspnetCoreMvcStarter.Models.CrowdFunding
{
    using System;

    public class Project
    {
        public int ProjectID { get; set; }
        public string RequestDate { get; set; } // تاریخ درخواست
        public string Symbol { get; set; } // نماد طرح
        public string PlatformName { get; set; } // نام سکو
        public string Applicant { get; set; } // متقاضی
        public string NationalID { get; set; } // شناسه ملی متقاضی
        public string ProjectTitle { get; set; } // عنوان طرح
        public string ApprovalDate { get; set; } // تاریخ تایید درخواست
        public decimal TotalFundingRequired { get; set; } // مبلغ کل مورد نیاز تامین مالی
        public decimal TotalRaisedAmount { get; set; } // مبلغ جمع آوری شده
        public decimal ActualRaisedAmount { get; set; } // مبلغ جمع آوری شده حقیقی
        public decimal LegalRaisedAmount { get; set; } // مبلغ جمع آوری شده حقوقی
        public int IndividualContributorsCount { get; set; } // تعداد مشارکت کننده حقیقی
        public int LegalContributorsCount { get; set; } // تعداد مشارکت کننده حقوقی
        public string FundCollectionDate { get; set; } // تاریخ جمع آوری وجوه
        public string ProjectStartDate { get; set; } // تاریخ شروع اجرای طرح
        public string ProjectEndDate { get; set; } // تاریخ اتمام پروژه
        public string Status { get; set; } // وضعیت
        public string CollateralType { get; set; } // نوع وثیقه
        public decimal InterestRate { get; set; } // سود علی الحساب
        public string PaymentFrequency { get; set; } // تواتر پرداخت
        public string FinancialInstitutionID { get; set; } // شناسه نهاد مالی
        public string FinancialInstitutionName { get; set; } // نام نهاد مالی
    }
}

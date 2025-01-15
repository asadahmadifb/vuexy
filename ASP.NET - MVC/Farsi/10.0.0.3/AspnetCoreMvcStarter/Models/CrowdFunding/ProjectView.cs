using System.ComponentModel.DataAnnotations;

namespace AspnetCoreMvcStarter.Models.CrowdFunding
{
  public class ProjectView
  {
    [Key]
    public int شناسه_طرح { get; set; }
    public string نام_طرح_یا_پروژه { get; set; }
    public decimal مبلغ_مورد_نیاز { get; set; }
    public string نوع_تامین_مالی_جمعی { get; set; }
    public string وضعیت_طرح { get; set; }
    public DateTime تاریخ_تایید_شده_شروع_جمع_آوری_وجوه { get; set; }
    public int دوره_جمع_آوری_وجوه { get; set; } // فرض بر این است که دوره به روزها یا ماه‌ها است
    public string نام_عامل { get; set; }
    public string لینک_عامل { get; set; }
    public string نام_سکو { get; set; }
    public string موضوع_طرح { get; set; }
    public string نام_شرکت { get; set; }
    public string نماد_طرح { get; set; }
    public string گروه_صنعت { get; set; }
    public string زیرگروه_صنعت { get; set; }
    public decimal حداقل_مبلغ_مورد_نیاز_جهت_موفقیت_تامین_مالی { get; set; }
    public decimal حداقل_مبلغ_سرمایه_گذاری_برای_تامین_کننده_حقیقی { get; set; }
    public decimal حداکثر_مبلغ_سرمایه_گذاری_برای_تامین_کننده_حقیقی { get; set; }
    public decimal حداقل_مبلغ_سرمایه_گذاری_برای_تامین_کننده_حقوقی { get; set; }
    public decimal حداکثر_مبلغ_سرمایه_گذاری_برای_تامین_کننده_حقوقی { get; set; }
    public DateTime تاریخ_پیشنهادی_شروع_جمع_آوری_وجوه { get; set; }
    public DateTime تاریخ_پیشنهادی_پایان_جمع_آوری_وجوه { get; set; }
    public DateTime تاریخ_شروع_پروژه { get; set; }
    public DateTime تاریخ_اتمام_پروژه { get; set; }
    public int تعداد_گواهی_شراکت_متقاضی { get; set; }
    public decimal کارمزد_فرابورس { get; set; }
    public decimal کارمزد_عامل { get; set; }
    public string نوع_وثیقه { get; set; }
    public string شناسه_ملی { get; set; }
    public string شماره_ثبت_شرکت { get; set; }
    public DateTime تاریخ_ثبت_شرکت { get; set; }
    public string کد_اقتصادی_شرکت { get; set; }
    public string نوع_شخصیت_حقوقی_شرکت { get; set; }
    public string کد_پستی_شرکت { get; set; }
  }
}

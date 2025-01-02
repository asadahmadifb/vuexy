using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace AspnetCoreMvcFull.Models
{
  public class Transactions
  {
    public int Id { get; set; }
    [Display(Name = "مشتری")]
    [StringLength(60, MinimumLength = 2, ErrorMessage = "نام مشتری 2 تا 60 کارکتر باید باشد")]
    [Required(ErrorMessage = "نام مشتری الزامی است")]
    public string? Customer { get; set; }
    [Display(Name = "تاریخ تراکنش")]
    [DataType(DataType.Date)]
    [Required(ErrorMessage = "تاریخ تراکنش الزامی است")]
    public DateTime TransactionDate { get; set; }
    [Display(Name = "تاریخ سررسید")]
    [DateGreaterThan("TransactionDate", ErrorMessage = "تاریخ سررسید باید بعد از تاریخ تراکنش باشد")]
    [DataType(DataType.Date)]
    [Required(ErrorMessage = "تاریخ سررسید الزامی است")]
    public DateTime DueDate { get; set; }
    [Display(Name = "مبلغ کل")]
    [DataType(DataType.Currency, ErrorMessage = "مبلغ کل باید عدد باشد")]
    [Required(ErrorMessage = "مبلغ کل الزامی است")]
    public decimal? Total { get; set; }
    [Display(Name = "وضعیت")]
    [Required(ErrorMessage = "وضعیت را انتخاب کنید")]
    public String? Status { get; set; }
  }

}

// For validation of DueDate > TransactionDate
public class DateGreaterThanAttribute : ValidationAttribute
{
    private readonly string _comparisonProperty;

    public DateGreaterThanAttribute(string comparisonProperty)
    {
        _comparisonProperty = comparisonProperty;
    }

    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        ErrorMessage = ErrorMessageString;
        var currentValue = (DateTime?)value;

        var property = validationContext.ObjectType.GetProperty(_comparisonProperty);

        if (property == null)
            throw new ArgumentException("Property with this name not found");

        var comparisonValue = (DateTime?)property.GetValue(validationContext.ObjectInstance);

        if (currentValue <= comparisonValue)
            return new ValidationResult(ErrorMessage);

        return ValidationResult.Success!;
    }
}

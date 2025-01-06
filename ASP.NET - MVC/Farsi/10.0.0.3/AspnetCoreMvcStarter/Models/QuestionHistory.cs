using System.ComponentModel.DataAnnotations;

namespace AspnetCoreMvcStarter.Models
{
    public class QuestionHistory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(500)] // محدودیت طول برای سوال
        public string question { get; set; }

        [Required]
        [MaxLength(500)] // محدودیت طول برای پاسخ
        public string response { get; set; }

        public DateTime Timestamp { get; set; }
        public string selectedOption { get; set; } // برای انتخاب یکی از گزینه‌ها

        public bool isDelete { get; set; }

        public string? UserId { get; set; }

    }
}

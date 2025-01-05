namespace AspnetCoreMvcStarter.Models
{
    // Models/Message.cs
    public class Message
    {
        public string Content { get; set; }
        public bool IsResponse { get; set; } // برای تعیین اینکه آیا پیام پاسخ است یا نه
    }
}

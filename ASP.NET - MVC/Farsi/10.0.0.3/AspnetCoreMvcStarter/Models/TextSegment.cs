namespace AspnetCoreMvcStarter.Models
{
    public class TextSegment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public byte[] Embedding { get; set; }
    }
    public class SearchResult
    {
        public string Answer { get; set; }
        public string FinalContent { get; set; }
    }
}

namespace AspnetCoreMvcStarter.Models
{
    public class DynamicGridModel
    {
        public List<string> Columns { get; set; }
        public List<Dictionary<string, object>> Rows { get; set; }
    }
}

namespace ASP_Web_API.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<QuoteTag> QuoteTags { get; set; } = new List<QuoteTag>();
    }
}

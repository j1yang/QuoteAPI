namespace ASP_Web_API.Models
{
    public class Quote
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }


        public List<QuoteTag> QuoteTags { get; set; } = new List<QuoteTag>();
        public List<Like> Likes { get; set; } = new List<Like>();
    }
}

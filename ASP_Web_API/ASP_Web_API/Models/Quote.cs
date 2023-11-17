namespace ASP_Web_API.Models
{
    public class Quote
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }


        public List<TagAssignment> TagAssignments { get; set; } = new List<TagAssignment>();
        public List<Like> Likes { get; set; } = new List<Like>();
    }
}

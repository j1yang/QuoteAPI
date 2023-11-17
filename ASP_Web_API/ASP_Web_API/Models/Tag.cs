namespace ASP_Web_API.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<TagAssignment> TagAssignments { get; set; } = new List<TagAssignment>();
    }
}

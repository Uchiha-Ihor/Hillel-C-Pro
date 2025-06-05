namespace WebApplication1.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<string> Tags { get; set; }

        public Note()
        {
            Tags = new List<string>();
            CreatedDate = DateTime.Now;
        }

        public string GetFormattedInfo()
        {
            return $"Title: {Title}\nContent: {Content}\nCreated: {CreatedDate}\nTags: {string.Join(", ", Tags)}";
        }

    }
}

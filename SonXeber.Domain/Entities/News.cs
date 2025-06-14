namespace SonXeber.Domain.Entities
{
    public class News
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;
        public string Content { get; set; } = default!;
        public DateTime PublishedDate { get; set; } = DateTime.UtcNow;
    }
}

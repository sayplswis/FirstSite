namespace MyNotes.Models
{
    public class Note(string title, string description)
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string Title { get; init; } = title;
        public string Description { get; init; } = description;
        public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    }
}

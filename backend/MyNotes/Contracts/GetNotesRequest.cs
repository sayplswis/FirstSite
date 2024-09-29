namespace MyNotes.Contracts
{
    public record GetNotesRequest(string? Search, string? SortItem, string? SortOrder);
    public record DeleteNoteRequest(Guid id);
}

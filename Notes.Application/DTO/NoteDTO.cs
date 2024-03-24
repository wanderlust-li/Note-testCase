using Notes.Domain;

namespace Notes.Application.DTO;

public class NoteDTO : BaseEntity
{
    public string Title { get; set; }
    public string Content { get; set; }
}
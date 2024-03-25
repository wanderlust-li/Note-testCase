namespace Notes.Web.Models.DTO;

public class NoteDTO
{
    public string Title { get; set; }
    
    public string Content { get; set; }
    
    public int Id { get; set; }
    
    public DateTime? DateCreated { get; set; }
    
    public DateTime? DateModified { get; set; }
}
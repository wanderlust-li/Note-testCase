using Notes.Domain.Entities;

namespace Notes.Application.IRepository;

public interface INoteRepository : IGenericRepository<Note>
{
    Task<List<Note>> GetNotes();

    Task AddNote(Note note);

    Task<Note> GetNote(int id);
}
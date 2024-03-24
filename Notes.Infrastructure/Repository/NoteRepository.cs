using Microsoft.EntityFrameworkCore;
using Notes.Application.IRepository;
using Notes.Domain.Entities;
using Notes.Infrastructure.DatabaseContext;

namespace Notes.Infrastructure.Repository;

public class NoteRepository : GenericRepository<Note>, INoteRepository
{
    public NoteRepository(NoteDatabaseContext context) : base(context)
    {
    }

    public async Task<List<Note>> GetNotes()
    {
        var notes = await _context.Notes
            .ToListAsync();

        return notes;
    }

    public async Task AddNote(Note note)
    {
        await _context.AddAsync(note);
        await _context.SaveChangesAsync();
    }

    public async Task<Note> GetNote(int id)
    {
        var note = await _context.Notes
            .FirstOrDefaultAsync(u => u.Id == id);

        return note;
    }
}
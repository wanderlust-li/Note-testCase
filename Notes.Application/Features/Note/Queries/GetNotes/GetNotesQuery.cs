using MediatR;
using Notes.Application.DTO;

namespace Notes.Application.Features.Note.Queries.GetNotes;

public class GetNotesQuery : IRequest<List<NoteDTO>>
{
    
}
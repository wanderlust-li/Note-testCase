using MediatR;
using Notes.Application.DTO;

namespace Notes.Application.Features.Note.Queries.GetNote;

public class GetNoteQuery : IRequest<NoteDTO>
{
    public int Id { get; set; }
}
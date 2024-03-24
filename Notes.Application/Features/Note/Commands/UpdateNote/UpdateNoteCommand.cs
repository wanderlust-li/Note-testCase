using MediatR;
using Notes.Application.DTO;

namespace Notes.Application.Features.Note.Commands.UpdateNote;

public class UpdateNoteCommand : IRequest<Unit>
{
    public UpdateNoteDTO UpdateNoteDto { get; set; }
}
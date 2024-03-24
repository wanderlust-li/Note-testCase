using MediatR;

namespace Notes.Application.Features.Note.Commands.DeleteNote;

public class DeleteNoteCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
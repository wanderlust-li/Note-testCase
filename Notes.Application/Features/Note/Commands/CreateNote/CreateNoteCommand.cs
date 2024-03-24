using MediatR;
using Notes.Application.DTO;

namespace Notes.Application.Features.Note.Commands.CreateNote;

public class CreateNoteCommand : IRequest<int>
{
    public CreateNoteDTO CreateNoteDto { get; set; }
}
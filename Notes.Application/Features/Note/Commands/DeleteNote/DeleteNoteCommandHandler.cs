using MediatR;
using Notes.Application.Exceptions;
using Notes.Application.IRepository;

namespace Notes.Application.Features.Note.Commands.DeleteNote;

public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand, Unit>
{
    private readonly INoteRepository _noteRepository;

    public DeleteNoteCommandHandler(INoteRepository noteRepository)
    {
        _noteRepository = noteRepository;
    }
    
    public async Task<Unit> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
    {
        var note = await _noteRepository.GetNote(request.Id);
        if (note == null)
            throw new NotFoundException($"Note with ID {request.Id}");

        await _noteRepository.DeleteAsync(note);

        return Unit.Value;
    }
}
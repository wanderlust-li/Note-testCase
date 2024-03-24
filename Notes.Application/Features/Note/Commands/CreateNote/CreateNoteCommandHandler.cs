using AutoMapper;
using MediatR;
using Notes.Application.IRepository;

namespace Notes.Application.Features.Note.Commands.CreateNote;

public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, int>
{
    private readonly INoteRepository _noteRepository;
    private readonly IMapper _mapper;

    public CreateNoteCommandHandler(INoteRepository noteRepository, IMapper mapper)
    {
        _noteRepository = noteRepository;
        _mapper = mapper;
    }
    
    public async Task<int> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
    {
        var createNote = _mapper.Map<Domain.Entities.Note>(request.CreateNoteDto);

        await _noteRepository.CreateAsync(createNote);
        
        return createNote.Id;
    }
}
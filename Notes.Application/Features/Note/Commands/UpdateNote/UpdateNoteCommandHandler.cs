using AutoMapper;
using MediatR;
using Notes.Application.Exceptions;
using Notes.Application.IRepository;

namespace Notes.Application.Features.Note.Commands.UpdateNote;

public class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommand, Unit>
{
    private readonly INoteRepository _noteRepository;
    private readonly IMapper _mapper;

    public UpdateNoteCommandHandler(INoteRepository noteRepository, IMapper mapper)
    {
        _noteRepository = noteRepository;
        _mapper = mapper;
    }
    
    public async Task<Unit> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
    {
        if (request.UpdateNoteDto == null) 
        {
            throw new BadRequestException("Invalid Note Data.");
        }
    
        var existingNote = await _noteRepository.GetNote(request.UpdateNoteDto.Id);
        if (existingNote == null) 
        {
            throw new NotFoundException($"Note with ID {request.UpdateNoteDto.Id} not found.");
        }
        
        _mapper.Map(request.UpdateNoteDto, existingNote); 
        existingNote.DateModified = DateTime.Now;

        await _noteRepository.UpdateAsync(existingNote); 
    
        return Unit.Value;
    }

}
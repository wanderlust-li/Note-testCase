using AutoMapper;
using MediatR;
using Notes.Application.DTO;
using Notes.Application.Exceptions;
using Notes.Application.IRepository;

namespace Notes.Application.Features.Note.Queries.GetNote;

public class GetNoteRequestHandler : IRequestHandler<GetNoteQuery, NoteDTO>
{
    private readonly INoteRepository _noteRepository;
    private readonly IMapper _mapper;

    public GetNoteRequestHandler(INoteRepository noteRepository, IMapper mapper)
    {
        _noteRepository = noteRepository;
        _mapper = mapper;
    }
    
    public async Task<NoteDTO> Handle(GetNoteQuery request, CancellationToken cancellationToken)
    {
        var note = await _noteRepository.GetNote(request.Id);
        
        if (note == null)
            throw new NotFoundException($"Note with ID {request.Id}");

        return _mapper.Map<NoteDTO>(note);
    }
}
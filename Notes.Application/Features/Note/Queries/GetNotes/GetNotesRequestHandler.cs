using AutoMapper;
using MediatR;
using Notes.Application.DTO;
using Notes.Application.Exceptions;
using Notes.Application.IRepository;

namespace Notes.Application.Features.Note.Queries.GetNotes;

public class GetNotesRequestHandler : IRequestHandler<GetNotesQuery, List<NoteDTO>>
{
    private readonly INoteRepository _noteRepository;
    private readonly IMapper _mapper;

    public GetNotesRequestHandler(INoteRepository noteRepository, IMapper mapper)
    {
        _noteRepository = noteRepository;
        _mapper = mapper;
    }
    
    public async Task<List<NoteDTO>> Handle(GetNotesQuery request, CancellationToken cancellationToken)
    {
        var notes = await _noteRepository.GetNotes();

        if (notes == null)
            throw new NotFoundException("Not found notes");

        return _mapper.Map<List<NoteDTO>>(notes);
    }
}
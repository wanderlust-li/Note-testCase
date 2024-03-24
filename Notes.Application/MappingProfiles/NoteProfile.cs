using AutoMapper;
using Notes.Application.DTO;
using Notes.Domain.Entities;

namespace Notes.Application.MappingProfiles;

public class NoteProfile : Profile
{
    public NoteProfile()
    {
        CreateMap<NoteDTO, Note>().ReverseMap();
        CreateMap<Note, NoteDTO>();

        CreateMap<CreateNoteDTO, Note>();
        CreateMap<UpdateNoteDTO, Note>()
            .ForMember(u => u.DateCreated, opt => opt.Ignore());
    }
}
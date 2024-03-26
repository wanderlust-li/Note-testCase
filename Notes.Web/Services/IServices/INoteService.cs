using Notes.Web.Models.DTO;

namespace Notes.Web.Services.IServices;

public interface INoteService
{
    Task<T> GetAllAsync<T>();
    
    Task<T> GetAsync<T>(int id);
    
    Task<T> CreateAsync<T>(NoteCreateDTO dto);
    
    
}
using Notes.Web.Models;
using Notes.Web.Models.DTO;
using Notes.Web.Services.IServices;

namespace Notes.Web.Services;

public class NoteService : BaseService, INoteService
{
    private readonly IHttpClientFactory _clientFactory;
    private string noteUrl;
    
    public NoteService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
    {
        _clientFactory = clientFactory;
        noteUrl = configuration.GetValue<string>("ServiceUrls:NoteAPI");
    }

    public Task<T> GetAllAsync<T>()
    {
        return SendAsync<T>(new APIRequest()
        {
            ApiType = ApiType.GET,
            Url = noteUrl + "/Note/get-all-notes"
        });
    }

    public Task<T> GetAsync<T>(int id)
    {
        return SendAsync<T>(new APIRequest()
        {
            ApiType = ApiType.GET,
            Url = noteUrl + "/Note/int:" + id
        });
    }
    
    public Task<T> CreateAsync<T>(NoteCreateDTO dto)
    {
        return SendAsync<T>(new APIRequest()
        {
            ApiType = ApiType.POST,
            Data = dto,
            Url = noteUrl + "/Note/create-note"
        });
    }
}
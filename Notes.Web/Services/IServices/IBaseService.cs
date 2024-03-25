using Notes.Web.Models;

namespace Notes.Web.Services.IServices;

public interface IBaseService
{
    APIResponse responseModel { get; set; }

    Task<T> SendAsync<T>(APIRequest apiRequest);
}
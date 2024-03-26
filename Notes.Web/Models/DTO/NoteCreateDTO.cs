using System.Text.Json.Serialization;

namespace Notes.Web.Models.DTO;

public class NoteCreateDTO
{
    [JsonPropertyName("title")] // Or [JsonProperty("title")] if using Newtonsoft.Json
    public string Title { get; set; }

    [JsonPropertyName("content")] // Or [JsonProperty("content")] if using Newtonsoft.Json
    public string Content { get; set; }
}
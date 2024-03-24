using MediatR;
using Microsoft.AspNetCore.Mvc;
using Notes.Application.DTO;
using Notes.Application.Features.Note.Commands.CreateNote;
using Notes.Application.Features.Note.Commands.DeleteNote;
using Notes.Application.Features.Note.Commands.UpdateNote;
using Notes.Application.Features.Note.Queries.GetNote;
using Notes.Application.Features.Note.Queries.GetNotes;

namespace Notes.API.Controllers;

[ApiController]
[Route("[controller]")]
public class NoteController : ControllerBase
{
    private readonly IMediator _mediator;

    public NoteController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("int:{id}")]
    public async Task<IActionResult> GetNoteById(int id)
    {
        var note = await _mediator.Send(new GetNoteQuery { Id = id });
        return Ok(note);
    }

    [HttpGet("get-all-notes")]
    public async Task<IActionResult> GetNotes()
    {
        var notes = await _mediator.Send(new GetNotesQuery());
        return Ok(notes);
    }

    [HttpPost("create-note")]
    public async Task<IActionResult> CreateNote(CreateNoteDTO createNote)
    {
        var note = await _mediator.Send(new CreateNoteCommand { CreateNoteDto = createNote });
        return Ok(note);
    }

    [HttpDelete("delete-note")]
    public async Task<IActionResult> DeleteNote(int id)
    {
        var deleteNote = await _mediator.Send(new DeleteNoteCommand { Id = id });
        return Ok(deleteNote);
    }

    [HttpPut("update-note")]
    public async Task<IActionResult> UpdateNote(UpdateNoteDTO updateNoteDto)
    {
        var updateNote = await _mediator.Send(new UpdateNoteCommand { UpdateNoteDto = updateNoteDto});
        return Ok(updateNote);
    }
    
}
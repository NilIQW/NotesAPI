using Microsoft.AspNetCore.Mvc;
using NotesAPI.Models;
using NotesAPI.Repository;

namespace NotesAPI.Controllers;


[ApiController]
[Route("api/[controller]")]
public class NoteController : ControllerBase
{
    private readonly INoteRepository _noteRepository;

    public NoteController(INoteRepository noteRepository)
    {
        _noteRepository = noteRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Note>>> GetNotes()
    {
        var notes = await _noteRepository.GetAllNotesAsync();
        return Ok(notes);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Note>> GetNoteById(int id)
    {
        var note = await _noteRepository.GetNoteByIdAsync(id);
        if (note == null)
        {
            return NotFound();
        }
        return Ok(note);
    }

    [HttpPost]
    public async Task<ActionResult<Note>> CreateNote([FromBody] Note note)
    {
        await _noteRepository.CreateNoteAsync(note);
        return CreatedAtAction(nameof(GetNoteById), new { id = note.Id }, note);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateNote(int id, [FromBody] Note note)
    {
        if (id != note.Id)
        {
            return BadRequest();
        }

        await _noteRepository.UpdateNoteAsync(note);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteNoteAsync(int id)
    {
        await _noteRepository.DeleteNoteAsync(id);
        return NoContent();
    }
    
}
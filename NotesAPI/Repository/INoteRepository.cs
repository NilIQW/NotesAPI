using NotesAPI.Models;

namespace NotesAPI.Repository;

public interface INoteRepository
{
    Task<IEnumerable<Note>> GetAllNotesAsync();
    Task<Note> GetNoteByIdAsync(int id);
    Task<Note> CreateNoteAsync(Note note);
    Task UpdateNoteAsync(Note note);
    Task DeleteNoteAsync(int id);
}

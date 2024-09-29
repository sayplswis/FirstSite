using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyNotes.Contracts;
using MyNotes.DataAccess;
using MyNotes.Models;
using System.Linq.Expressions;

namespace MyNotes.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly NotesDbContext _dbContext;
        public NotesController(NotesDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateNoteRequest request)
        {
            var note = new Note(request.Title, request.Description);
            await _dbContext.Notes.AddAsync(note);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            await _dbContext.Notes.Where(x=>x.Id == id).ExecuteDeleteAsync();
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]GetNotesRequest request)
        {
            var notesQuery = _dbContext.Notes
                .Where(n => string.IsNullOrEmpty(request.Search) || n.Title.ToLower().Contains(request.Search.ToLower()));

            if(request.SortOrder == "desc")
                notesQuery = notesQuery.OrderByDescending(GetSelectorKey(request.SortItem));
            else
                notesQuery = notesQuery.OrderBy(GetSelectorKey(request.SortItem));

            var notes = await notesQuery.ToListAsync();

            return Ok(notes);
        }

        private Expression<Func<Note, object>> GetSelectorKey(string sortItem)
        {
            return sortItem switch
            {
                "title" => note => note.Title,
                "description" => note => note.Description,
                _ => note => note.CreatedAt
            };
        }
    } 
}

using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class NotesController : Controller
    {
        private static List<Note> notes = new List<Note>();

        public IActionResult Index()
        {
            return View(notes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Note note, string tagsInput)
        {
            if (ModelState.IsValid)
            {
                note.Id = notes.Count + 1;
                note.Tags = tagsInput?.Split(',').Select(t => t.Trim()).ToList() ?? new List<string>();
                notes.Add(note);
                return RedirectToAction("Index");
            }
            return View(note);
        }
    }
}

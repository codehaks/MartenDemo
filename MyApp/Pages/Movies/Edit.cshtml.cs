using System.Linq;
using Marten;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyApp.Models;

namespace MyApp.Pages.Movies
{
    public class EditModel : PageModel
    {
        private readonly IDocumentStore _store;

        public EditModel(IDocumentStore store)
        {
            _store = store;
        }

        [BindProperty]
        public Movie Movie { get; set; }

        public void OnGet(int id)
        {
            using var session = _store.LightweightSession();
            Movie = session.Query<Movie>().FirstOrDefault(m => m.Id == id);

        }

        public IActionResult OnPost()
        {
            using var session = _store.LightweightSession();

            session.Update(Movie);
            session.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}
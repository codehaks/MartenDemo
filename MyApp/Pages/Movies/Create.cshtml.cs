using Marten;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyApp.Data;
using MyApp.Models;

namespace MyApp.Pages.Movies
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Movie Movie { get; set; }

        private readonly IDocumentStore _store;

        public CreateModel(IDocumentStore store)
        {
            _store = store;
        }

        public IActionResult OnPost()
        {
            using var session = _store.LightweightSession();
            session.Store(Movie);
            session.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}
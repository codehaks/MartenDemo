using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marten;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyApp.Data;
using MyApp.Models;

namespace MyApp.Pages.Movies
{
    public class DeleteModel : PageModel
    {
        private readonly IDocumentStore _store;

        public DeleteModel(IDocumentStore store)
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

            session.Delete(Movie);
            session.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using Marten;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyApp.Models;

namespace MyApp.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly IDocumentStore _store;

        public IndexModel(IDocumentStore store)
        {
            _store = store;
        }

        public IList<Movie> MovieList { get; set; }
        public void OnGet()
        {

            using var session = _store.LightweightSession();
            MovieList=session.Query<Movie>().ToList();

        }
    }
}
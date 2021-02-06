using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyApp.Application.Movies;
using MyApp.Data;
using MyApp.Models;

namespace MyApp.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly IMediator _mediator;
        public IndexModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IList<Movie> MovieList { get; set; }
        public async Task<IActionResult> OnGet()
        {
            var res = await _mediator.Send(new Index.Query());
            MovieList = res.Movies;
            return Page();
        }
    }
}
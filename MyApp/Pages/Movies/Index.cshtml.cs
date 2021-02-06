using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyApp.Application.Movies;
using MyApp.Data;
using MyApp.Models;

namespace MyApp.Pages.Movies
{
    public class IndexModel : PageModel
    {

        private IMediator _mediator;

        public IndexModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IList<Movie> MovieList { get; set; }
        public async Task<IActionResult> OnGet()
        {
            var response = await _mediator.Send(new IndexQuery.Request());
            MovieList = response.MovieList;
            return Page();
        }

      
    }
}
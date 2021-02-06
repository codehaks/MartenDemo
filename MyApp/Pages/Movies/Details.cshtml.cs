using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyApp.Application.Movies;
using MyApp.Models;

namespace MyApp.Pages.Movies
{
    public class DetailsModel : PageModel
    {
        private readonly IMediator _mediator;

        public DetailsModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Movie Movie { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            var response=await _mediator.Send(new FindQuery.Request { Id=id});
            Movie = response.Movie;
            return Page();
        }
    }
}

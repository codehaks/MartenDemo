using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyApp.Application.Movies;
using MyApp.Data;
using MyApp.Models;
using System.Threading.Tasks;

namespace MyApp.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly IMediator _mediator;

        public CreateModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        [BindProperty]
        public Movie Movie { get; set; }

       

        public async Task<IActionResult> OnPost()
        {
            var response= await _mediator.Send(new CreateCommand.Request
            {
                Movie=Movie
            });

            TempData["id"] = response.Id;

            return RedirectToPage("Index");
        }
    }
}
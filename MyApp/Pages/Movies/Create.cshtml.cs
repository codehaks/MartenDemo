using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyApp.Application;
using MyApp.Application.Movies;
using MyApp.Data;
using MyApp.Models;
using System.Threading.Tasks;

namespace MyApp.Pages.Movies
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Movie Movie { get; set; }

        private readonly IMediator _mediator;

        public CreateModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> OnPost()
        {


            var respose=await _mediator.Send(new Create.Command
            {
                Name = Movie.Name,
                Year = Movie.Year
            });

            ViewData["id"] = respose.Id;

            _ = _mediator.Publish(new Message { UserId = "codehaks", Subject = "My Test" });

            return RedirectToPage("Index");
        }
    }
}
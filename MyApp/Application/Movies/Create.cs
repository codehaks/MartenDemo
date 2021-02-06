using MediatR;
using MyApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyApp.Application.Movies
{
    public class Create
    {
        public class Command:IRequest<Response>
        {
            public string Name { get; set; }
            public int Year { get; set; }
        }

        public class Handler : IRequestHandler<Command, Response>
        {
            private readonly AppDbContext _db;

            public Handler(AppDbContext db)
            {
                _db = db;
            }

            public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
            {
                var model=_db.Movies.Add(new Models.Movie
                {
                    Name = request.Name,
                    Year = request.Year
                });

                await _db.SaveChangesAsync();

                return new Response
                {
                    Id = model.Entity.Id
                };
            }
        }

        public class Response
        {
            public int Id { get; set; }
        }
    }
}

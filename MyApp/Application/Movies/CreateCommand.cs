using MediatR;
using MyApp.Data;
using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyApp.Application.Movies
{
    public class CreateCommand
    {
        public class Request : IRequest<Response>
        {
            public Movie Movie { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly AppDbContext _db;

            public Handler(AppDbContext db)
            {
                _db = db;
            }

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var model = _db.Add(request.Movie);
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

using MediatR;
using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyApp.Application.Movies
{
    public class FindQuery
    {
        public class Request : IRequest<Response>
        {
            public int Id { get; set; }
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
                var model = await _db.Movies.FindAsync(request.Id);
                return new Response
                {
                    Movie = model
                };

            }
        }
        public class Response
        {
            public Movie Movie { get; set; }
        }
    }
}

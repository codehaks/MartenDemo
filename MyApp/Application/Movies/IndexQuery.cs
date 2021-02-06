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
    public class IndexQuery
    {
        public class Request : IRequest<Response>
        {

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
                var model = await _db.Movies.ToListAsync(cancellationToken);
                return new Response
                {
                    MovieList = model
                };

            }
        }
        public class Response
        {
            public IList<Movie> MovieList { get; set; }
        }
    }
}

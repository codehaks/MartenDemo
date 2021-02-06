using MediatR;
using Microsoft.CodeAnalysis;
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
    public class Index
    {
        public class Query:IRequest<Response>
        {

        }

        public class Handler : IRequestHandler<Query, Response>
        {
            private readonly AppDbContext _db;

            public Handler(AppDbContext db)
            {
                _db = db;
            }

            public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
            {
                var model = await _db.Movies.ToListAsync();
                return new Response
                {
                    Movies = model
                };
            }
        }

        public class Response
        {
            public IList<Movie> Movies { get; set; }
        }
    }
}

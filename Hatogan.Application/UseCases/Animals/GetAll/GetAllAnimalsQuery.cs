using Hatogan.Application.Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hatogan.Application.UseCases.Animals.GetAll
{
    public class GetAllAnimalsQuery : IRequest<IResult>
    {


        internal class GetAllAnimalsQueryHandler : IRequestHandler<GetAllAnimalsQuery, IResult>
        {
            private readonly ApplicationDbContext _context;

            public GetAllAnimalsQueryHandler(ApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<IResult> Handle(GetAllAnimalsQuery request, CancellationToken cancellationToken)
            {
                var result = await _context.Animals.ToListAsync();

                return Results.Ok(result);
            }
        }
    }
}

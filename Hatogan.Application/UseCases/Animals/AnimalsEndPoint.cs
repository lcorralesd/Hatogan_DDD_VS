using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hatogan.Application.UseCases.Animals
{
    public static class AnimalsEndPoint
    {
        public static WebApplication UseAnimalEndPoint(this WebApplication app)
        {
            app.MapPost("api/animals", new AnimalsRoutes().CreateAnimal);

            return app;
        }
    }
}

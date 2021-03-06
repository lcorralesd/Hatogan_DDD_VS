using Carter;
using FluentValidation;
using Hatogan.Application.Common.Behaviors;
using Hatogan.Application.Infrastructure.Data;
using Hatogan.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Hatogan.Application
{
    public static class DependencyContainer
    {
        public static IServiceCollection ConfigureApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("Default")));

            //services.AddScoped(typeof(IInventoryContext), provider => provider.GetService<ApplicationDbContext>()!);

            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            //services.AddCarter();

            return services;
        }
    }
}

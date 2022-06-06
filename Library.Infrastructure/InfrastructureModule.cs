using Library.Core.Abstractions;
using Library.Infrastructure.Data;
using Library.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure
{
    public static class InfrastructureModule
    {
        public static void RegisterInfrastructureServices(this IServiceCollection services)
        {
            services.AddDbContext<LibraryContext>(ServiceLifetime.Transient);

            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IDvdRepository, DvdRepository>();
        }
    }
}

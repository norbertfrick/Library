﻿using Library.Core.Abstractions;
using Library.Infrastructure.Data;
using Library.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
        public static void RegisterInfrastructureServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<LibraryContext>((options)=> options.UseSqlServer(config.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Library.Infrastructure")), ServiceLifetime.Transient);

            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IDvdRepository, DvdRepository>();
            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<IRentalEntryRepository, RentalEntryRepository>();
            services.AddScoped<IQueueItemRepository, QueueItemRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
        }
    }
}

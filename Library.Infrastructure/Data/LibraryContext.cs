using Library.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(): base()
        {
            //this._connectionString = connectionString;
        }

        private string _connectionString = @"Server=N-PC\SQLEXPRESS;Database=LibraryDb;Trusted_Connection=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString, b => b.MigrationsAssembly("Library.Infrastructure"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Book> Book { get; set; }
        public DbSet<Dvd> Dvds { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<RentalEntry> RentalEntries { get; set; }
        public DbSet<QueueItem> QueueItems { get; set; }

        public DbSet<Message> Messages { get; set; }

    }
}

using E_ticket.DLL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace E_ticket.DLL.Contexts
{
    public class E_TicketDbContext:DbContext
    {
        public E_TicketDbContext(DbContextOptions<E_TicketDbContext> options ):base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Movies_Actors> ActorsMovies { get; set; }

        public DbSet<Producer> Producers { get; set; }

    }
}

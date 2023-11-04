using E_ticket.BLL.Repositries;
using E_ticket.DLL.Contexts;
using E_ticket.DLL.Models;
using E_Ticket.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Ticket.BLL.Repositries
{
    public class UnitOfWork : IUnitOfWork 
    {

    
    
        private readonly E_TicketDbContext context;

       
    
        public GenericRepository<Actor> ActorgenericRepository { get ; set; }
        public GenericRepository<Cinema> CinemagenericRepository { get; set ; }
        public GenericRepository<Movie> MoviegenericRepository { get ; set ; }
        public GenericRepository<Producer> ProducergenericRepository { get ; set ; }

        public UnitOfWork(E_TicketDbContext context)
        {
            this.context = context;

            ActorgenericRepository = new GenericRepository<Actor>(context);
            CinemagenericRepository = new GenericRepository<Cinema>(context);
            MoviegenericRepository = new GenericRepository<Movie>(context);
            ProducergenericRepository=new GenericRepository<Producer>(context);
        }


        public async Task<int> Complete()
        {
           return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}

using E_ticket.BLL.Repositries;
using E_ticket.DLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Ticket.BLL.Interfaces
{
    public interface IUnitOfWork:IDisposable 
    {
        public GenericRepository<Actor> ActorgenericRepository { get; set; }
        public GenericRepository<Cinema> CinemagenericRepository { get; set; }

        public GenericRepository<Movie> MoviegenericRepository { get; set; }

        public GenericRepository<Producer> ProducergenericRepository { get; set; }



        public Task<int> Complete();

    }
}

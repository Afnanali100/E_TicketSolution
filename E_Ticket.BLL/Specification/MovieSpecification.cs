using E_ticket.DLL.Models;
using E_Ticket.BLL.Repositries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Ticket.BLL.Specification
{
    public class MovieSpecification:BaseSpecification<Movie>
    {
        public MovieSpecification()
        {
            Include.Add(M => M.cinema);   
        }


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_ticket.DLL.Models
{
    public class Movies_Actors
    {
       public int Id { get; set; }

        //Movie Relationship

        [ForeignKey("Movies")]
        public int MovieId { get; set; }
        public Movie Movies { get; set;}


        //Actor Relationship

        [ForeignKey("Actors")]
        public int ActorId { get; set; }
        public Actor Actors { get; set;}
    }
}

using E_ticket.DLL.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Ticket.ViewModels
{
    public class MoviesActorViewModel
    {

        public int Id { get; set; }

        //Movie Relationship

        [ForeignKey("Movies")]
        public int MovieId { get; set; }
        public Movie Movies { get; set; }


        //Actor Relationship

        [ForeignKey("Actors")]
        public int ActorId { get; set; }
        public Actor Actors { get; set; }
    }
}

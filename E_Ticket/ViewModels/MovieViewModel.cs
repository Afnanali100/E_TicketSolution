using E_ticket.BLL.Data.DataSeed;
using E_ticket.DLL.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;

namespace E_Ticket.ViewModels
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        [Display(Name = "Movie Image")]
        public string ImageURL { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public MovieCategory Moviecategory { get; set; }

        //Actors Realtionship
        public ICollection<Movies_Actors> Movie_Actor { get; set; } = new HashSet<Movies_Actors>();


        //Cinema Relationship

        [ForeignKey("cinema")]
        public int CinemaId { get; set; }
        public Cinema cinema { get; set; }


        //Producer Relationship

        [ForeignKey("producer")]
        public int ProducerId { get; set; }

        public Producer producer { get; set; }
    }
}

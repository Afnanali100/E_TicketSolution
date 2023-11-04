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
        [Required(ErrorMessage ="Name is Required!")]
        [MaxLength(30)]
        [MinLength(5)]
        public string Name { get; set; }

        [Required(ErrorMessage ="Description is required!")]
        public string Description { get; set; }

        [Required(ErrorMessage ="Price is Required")]
        [Range(0,10000)]
        public decimal Price { get; set; }

        [Required(ErrorMessage ="Image is Required")]
        [Display(Name = "Movie Image")]
        public string ImageURL { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        
        
        [Display(Name = "Category")]

        [Required(ErrorMessage ="Category is Required")]
        public MovieCategory Moviecategory { get; set; }

        //Actors Realtionship
        [Display(Name = "Actors")]
        public ICollection<Movies_Actors> Movie_Actor { get; set; } = new HashSet<Movies_Actors>();


        //Cinema Relationship
        [Display(Name ="Cinema")]
        [ForeignKey("cinema")]
        public int CinemaId { get; set; }
        public Cinema cinema { get; set; }


        //Producer Relationship
        [Display(Name = "Producer")]
        [ForeignKey("producer")]
        public int ProducerId { get; set; }

        public Producer producer { get; set; }
    }
}

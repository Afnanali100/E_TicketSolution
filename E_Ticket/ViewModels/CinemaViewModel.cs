using E_ticket.DLL.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace E_Ticket.ViewModels
{
    public class CinemaViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Logo is Required")]
        [Display(Name = "Cinema Logo")]
        public string Logo { get; set; }
        [Required(ErrorMessage ="The Name Is Required")]
        [MaxLength(50,ErrorMessage ="Max Length is 50 characher")]
        [MinLength(5,ErrorMessage ="Min Length is 8 charchter")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Description is required")]
        public string Description { get; set; }

        //Movie Relationship
        public ICollection<Movie> Movies { get; set; } = new HashSet<Movie>();
    }
}

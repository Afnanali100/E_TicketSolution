using E_ticket.DLL.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace E_Ticket.ViewModels
{
    public class ProducerViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Profile Picture Is Required")]
        [Display(Name = "Profile Picture")]
        public string ProfilePictureURL { get; set; }


        [MaxLength(20, ErrorMessage = "Max Length is 20")]
        [MinLength(5, ErrorMessage = "Min Lengths is 5")]
        [Required(ErrorMessage = "FullName Is Required")]

        public string FullName { get; set; }

        [Required(ErrorMessage = "Biography Is Required")]
        [Display(Name = "Biography")]
        public string Bio { get; set; }
        // Movie Relationship
        public ICollection<Movie> Movies { get; set; } = new HashSet<Movie>();
    }
}

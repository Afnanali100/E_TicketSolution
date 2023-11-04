using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_ticket.DLL.Models
{
    public class Producer:BaseEntity
    {
       
        public string ProfilePictureURL { get; set; }

       
        public string FullName { get; set; }

 
        public string Bio { get; set; }

        // Movie Relationship
        public ICollection<Movie> Movies { get; set; } = new HashSet<Movie>();
    }
}

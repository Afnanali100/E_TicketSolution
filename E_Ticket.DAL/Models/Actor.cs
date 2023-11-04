using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_ticket.DLL.Models
{
    public class Actor:BaseEntity
    {
    
        public string ProfilePictureURL { get; set; }


        public string FullName { get; set; }

   
        public string Bio { get; set; }


        //Movie Relationship
        public ICollection<Movies_Actors> Movie_Actor { get; set; } = new HashSet<Movies_Actors>();
    }
}

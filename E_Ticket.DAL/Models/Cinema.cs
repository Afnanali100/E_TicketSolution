using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace E_ticket.DLL.Models
{
    public class Cinema : BaseEntity
    {
    
        public string Logo { get; set; }

        public string Name { get; set; }

        public string Description { get; set; } 

        //Movie Relationship
        public ICollection<Movie> Movies { get; set; }=new HashSet<Movie>();


    }
}

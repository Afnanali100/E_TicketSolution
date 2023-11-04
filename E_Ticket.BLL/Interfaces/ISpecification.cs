using E_ticket.DLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Ticket.BLL.Interfaces
{
    public interface ISpecification<T> where T : BaseEntity
    {

        public Expression<Func<T,bool>> Creteria { get; set; }

        public List<Expression<Func<T,object>>> Include { get; set; }

    }
}

using E_ticket.DLL.Models;
using E_Ticket.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Ticket.BLL.Repositries
{
    public class BaseSpecification<T> : ISpecification<T> where T : BaseEntity
    {
        //p.id==id
        public Expression<Func<T, bool>> Creteria { get ; set ; }
        public List<Expression<Func<T, object>>> Include { get; set; } = new List<Expression<Func<T, object>>>();

        public BaseSpecification()
        {
            
        }

        public BaseSpecification(Expression<Func<T,bool>> Creteria)
        {
            this.Creteria = Creteria;
        }

    }
}

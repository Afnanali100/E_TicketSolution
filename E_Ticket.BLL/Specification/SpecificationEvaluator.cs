using E_ticket.DLL.Models;
using E_Ticket.BLL.Interfaces;
using E_Ticket.BLL.Repositries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Ticket.BLL.Specification
{
    public  static class  SpecificationEvaluator<T> where T : BaseEntity
    {
        public static IQueryable<T> GenerateQuery(IQueryable<T> InputQuery, ISpecification<T> spec)
        {
            var query = InputQuery;
            if (spec.Creteria != null)
                query = query.Where(spec.Creteria);

            //storeContext.Set<product>.Where(p=>p.id==id).
            //include(m=>m.cinema)           p=>p.cinema   
            query = spec.Include.Aggregate(query,(str1,str2)=>str1.Include(str2));

            return query;
        }


    }
}

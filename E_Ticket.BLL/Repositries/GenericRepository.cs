using E_ticket.BLL.Interfaces;
using E_ticket.DLL.Contexts;
using E_ticket.DLL.Models;
using E_Ticket.BLL.Interfaces;
using E_Ticket.BLL.Specification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_ticket.BLL.Repositries
{
    public class GenericRepository<T>: IGenericRepository<T> where T : BaseEntity
    {
        private readonly E_TicketDbContext context;

        public GenericRepository(E_TicketDbContext context)
        {
            this.context = context;
        }
        public void Delete(T item)
        {
          context.Set<T>().Remove(item);
           
        }

        public async Task<IEnumerable<T>> GetAllAsyncBySpecification( ISpecification<T> spec )
        {
            //if (typeof(T) == typeof(Movie))
            //    return (IEnumerable<T>) await context.Movies.Include(m => m.cinema).ToListAsync();

            return await ApplySpecification(spec).ToListAsync();

           // return await context.Set<T>().ToListAsync(); 
           
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
           return await context.Set<T>().ToListAsync();   
        }

      
        public async Task<T> GetById(int id)
        {
               return await context.Set<T>().FindAsync(id);
             
        }

        public  void Update(T item)
        {
            context.Set<T>().Update(item);
          
        }

        public async Task AddAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);

        }


        private  IQueryable<T> ApplySpecification( ISpecification<T> spec)
        {
            var query =  SpecificationEvaluator<T>.GenerateQuery(context.Set<T>(),spec);
            return query;
        }

       
    }
}

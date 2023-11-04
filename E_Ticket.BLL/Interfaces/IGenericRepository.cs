using E_ticket.DLL.Models;
using E_Ticket.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_ticket.BLL.Interfaces
{
    public interface IGenericRepository<T>where T : BaseEntity
    {
        public Task<IEnumerable<T>> GetAllAsync();
        
        
        public Task AddAsync(T entity);

        public Task<IEnumerable<T>> GetAllAsyncBySpecification(ISpecification<T> spec);

        public Task<T> GetById(int id);

        public void Update(T item);
        
        public void Delete (T item);


    }
}

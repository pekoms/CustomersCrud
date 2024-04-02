using CustomersCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomersCrud.Interfaces
{
    public interface ICustomerService
    {
        public  Task<List<Customers>> GetAllEntitiesAsync();


        public  Task<Customers> GetEntityByIdAsync(int id);


        public  Task<Customers> CreateEntityAsync(Customers entity);


        public  Task<Customers> UpdateEntityAsync(Customers entity);


        public  Task DeleteEntityAsync(int id);
    
    }
}

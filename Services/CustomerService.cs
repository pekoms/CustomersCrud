using CustomersCrud.Infrastructure;
using CustomersCrud.Interfaces;
using CustomersCrud.Models;
using Microsoft.EntityFrameworkCore;


namespace CustomersCrud.Services
{
    public class CustomerService:ICustomerService
    {
        private readonly CustomerContext _context;

        public CustomerService(CustomerContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Customers>> GetAllEntitiesAsync()
        {
            try
            {
                return await _context.Customers.ToListAsync();
            }
            catch(Exception ex) { }
            return null;
        }

        public async Task<Customers> GetEntityByIdAsync(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task<Customers> CreateEntityAsync(Customers entity)
        {
            _context.Customers.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Customers> UpdateEntityAsync(Customers entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteEntityAsync(int id)
        {
            var entity = await _context.Customers.FindAsync(id);
            if (entity == null)
            {
                throw new ArgumentException("Entity not found.");
            }

            _context.Customers.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using SupplyTrackr_API.Repository.Interface;
using SupplyTrackr_API.Models;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly SupplyTrackrDBContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(SupplyTrackrDBContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    // Add a new entity to the database
    public async Task<bool> AddAsync(T entity)
    {
        try
        {
            await _dbSet.AddAsync(entity);          // Add entity to DbSet
            await _context.SaveChangesAsync();      // Commit changes to database
            return true;                            // Return true if operation is successful
        }
        catch (Exception)
        {
            return false;                           // Return false if an error occurs
        }
    }

    // Update an existing entity
    public async Task<bool> UpdateAsync(T entity)
    {
       
        try
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return true;                            // Return true if operation is successful
        }
        catch (Exception)
        {
            return false;                           // Return false if an error occurs
        }
    }

    // Delete an entity by its ID
    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
                return true;

            }
            return false;                            // Return true if operation is successful
        }
        catch (Exception)
        {
            return false;                           // Return false if an error occurs
        }

        
    }

    // Get an entity by its ID
    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    // Get all entities
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    // Get entities that match a specific condition
    public async Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> expression)
    {
        return await _dbSet.Where(expression).ToListAsync();
    }
}

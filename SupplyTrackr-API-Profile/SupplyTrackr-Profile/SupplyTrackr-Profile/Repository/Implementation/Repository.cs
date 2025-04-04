using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using SupplyTrackr_Profile.Repository.Interface;
using SupplyTrackr_Profile.Models;

 namespace SupplyTrackr_Profile.Repository.Implementation
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly SupplyTrackrDBContext _context;
        private readonly DbSet<T> _dbSet;
        public Repository(SupplyTrackrDBContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<bool> AddAsync(T entity) // add new entity to the database
        {
            try
            {
                await _dbSet.AddAsync(entity); //add entity to Dbset
                await _context.SaveChangesAsync(); //Commit changes to DB
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        } // end of Add


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
                return false; // return true if operation successful
            }
            catch (Exception) { return false; } // return false if error

        } // end of update

        public async Task<T> GetByIdAsync(int id)
        { //get entity By ID
            return await _dbSet.FindAsync(id);

        }

        //get all entiti
        public async Task<IEnumerable<T>> GetAllAsync() { return await _dbSet.ToListAsync(); }


        //get entiti that match a specfici condi
        public async Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.Where(expression).ToListAsync();

        }

    }
}
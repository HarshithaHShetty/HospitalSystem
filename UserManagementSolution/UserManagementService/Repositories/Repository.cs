using System.Diagnostics;
using UserManagementService.Contexts;
using UserManagementService.Interfaces;

namespace UserManagementService.Repositories
{
    public abstract class Repository<T, K> : IRepository<T, K> where T : class
    {
        public abstract Task<ICollection<T>> Get();

        public abstract Task<T> Get(K key);


        protected AuthenticationContext _context;

        public async Task<T> Add(T entity) { 
            _context.Add(entity);//Take the entity asses its type and add it to the respective collection
            Debug.WriteLine(_context.Entry(entity).State);
            _context.SaveChanges();//Save the changes to the database
            return entity;
        }

        public async Task<T> Delete(K key)
        {

              var entity = await Get(key);
            if (entity != null)
            {
                _context.Remove(entity);
                _context.SaveChanges();
                return entity;
            }
            throw new Exception("Entity not found");
               
        }

        public async Task<T> Update(K key, T entity)
        {
            var myEntity = await Get(key);
            if (myEntity != null)
            {
                _context.Entry(myEntity).CurrentValues.SetValues(entity);
                _context.SaveChanges();
                return myEntity;
            }
            throw new Exception("Entity not found");
        }

    }
}
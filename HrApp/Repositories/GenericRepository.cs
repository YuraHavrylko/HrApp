namespace HrApp.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data.Entity;
    using System.Linq;

    using HrApp.Contract.Repositories;
    public class GenericRepository<T> : IRepository<T>
        where T : class
    {
        DbContext _context;
        DbSet<T> _dbSet;

        public GenericRepository(DbContext context)
        {
            //var conStr = ConfigurationManager.ConnectionStrings[connection];
            _context = context;
            _dbSet = context.Set<T>();
        }

        public T Get(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public IEnumerable<T> GetAllWhere(T person, int page, int count)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<T> Get(Func<T, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }

        public void Add(T person)
        {
            _dbSet.Add(person);
            _context.SaveChanges();
        }

        public void Edit(T person)
        {
            _context.Entry(person).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }
    }
}
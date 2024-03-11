using DataAccess.Abstract.EntityFramework;

using Entities.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Contexts;

namespace DataAccess.Concrete.EntityFramework
{
    public class EntityRepositoryBase<T> : IEntityRepository<T> where T : class, IEntity, new()
        
    {

        protected readonly BilgiSayarDbContext _context;//Readonly sadece get var set yok
        public EntityRepositoryBase(BilgiSayarDbContext context)
        {

            _context = context;
        }
        public void Add(T entity)
        {
            
                var AddEntity=_context.Entry(entity);
                AddEntity.State = EntityState.Added;
                _context.SaveChanges();

            
        }

        public void Delete(T entity)
        {
            
                var DeleteEntity = _context.Entry(entity);
                DeleteEntity.State = EntityState.Deleted;
                _context.SaveChanges();

            
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            
                return _context.Set<T>().SingleOrDefault(filter);

            
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
           
                return filter == null ? _context.Set<T>().ToList() 
                    : _context.Set<T>().Where(filter).ToList();

            
        }

        public void Update(T entity)
        {

            
                var UpdateEntity = _context.Entry(entity);
            UpdateEntity.State = EntityState.Modified;
            _context.SaveChanges();
            

        }
    }
}

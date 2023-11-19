using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity , TContext> : IEntityRepository<TEntity>// Tentity, product, customer vb. entitylerimi ifade ediyor, TContext = northwindcontext vb. EntityFramework kısmını bağımsız hale getirmiş oluyoruz.
        where TEntity : class , IEntity , new()
        where TContext : DbContext , new() 
    {

        public void Add(TEntity entity)
        {
            // using içerisine yazılan nesneler using bittiğinde garbage collector ile bellekten atılır. Programın perf. arttırmak amacıyla kullanılır.
            //IDisposable patter implementation of c#
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);  // contextin referansını yakalama
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);  // contextin referansını yakalama
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                // set ile product listemizi getiriyoruz, 
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                //dbset'teki (northwindContext) product tablosuna eriş, veritabanındaki tüm tabloyu listeye çevir. select * from prodcut çalıştırır ve onu listeye çevirir.
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public List<TEntity> GetAllByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);  // contextin referansını yakalama
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}

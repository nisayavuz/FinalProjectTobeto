using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    //NuGet => .net içerisinde entity  framework default olarak bir paketle gelir. Bunları kullanacağız.
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            // using içerisine yazılan nesneler using bittiğinde garbage collector ile bellekten atılır. Programın perf. arttırmak amacıyla kullanılır.
            //IDisposable patter implementation of c#
            using (NorthwindContext context = new NorthwindContext())
            {
                var addedEntity = context.Entry(entity);  // contextin referansını yakalama
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity);  // contextin referansını yakalama
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                // set ile product listemizi getiriyoruz, 
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                //dbset'teki (northwindContext) product tablosuna eriş, veritabanındaki tüm tabloyu listeye çevir. select * from prodcut çalıştırır ve onu listeye çevirir.
                return filter == null ? context.Set<Product>().ToList() : context.Set<Product>().Where(filter).ToList();
            }
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity);  // contextin referansını yakalama
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }


    }
}

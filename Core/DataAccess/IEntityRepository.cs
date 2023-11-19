using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

//Core diğer katmanları referans almaz.
namespace Core.DataAccess
{
    //generic costraint - generic kısıt: Tnin değerini kısıtlama
    //class : referans tip
    //new() = newlenebilir olmalı  
    public interface IEntityRepository<T> where T : class, IEntity , new() // T'ye vereceğim değer bir referans tip olmalı ve aynı zamanda Ientity ya da Ientity implemente eden classlardan biri olmalıdır.
    {
        List<T> GetAll(Expression<Func<T , bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        List<T> GetAllByCategory(int categoryId); // ürünleri kategoriye göre listele


    }
}

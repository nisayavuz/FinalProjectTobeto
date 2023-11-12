using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products; //global bir değişken oluşturdum. Burada bir veritabanından veri geliyormuş gibi davranıyoruz.
        //alt tire bir isimlendirme standardı. Global değişkeni ifade ediyor. 
        public InMemoryProductDal() //Bu bir constructor. Bellekte referans aldığı zaman çalışacak olan kod bloğudur. Program başladığında bu listenin gelmesi icin.
        {
            _products = new List<Product>
            {
                new Product { ProductId = 1, CategoryId = 1, ProductName = "Kalem", UnitPrice = 15, UnitsInStock = 15 },
                new Product { ProductId = 2, CategoryId = 1, ProductName = "Silgi", UnitPrice = 500, UnitsInStock = 3 },
                new Product { ProductId = 3, CategoryId = 2, ProductName = "Kamera", UnitPrice = 1500, UnitsInStock = 2 },
                new Product { ProductId = 4, CategoryId = 2, ProductName = "Telefon", UnitPrice = 150, UnitsInStock = 65 },
                new Product { ProductId = 5, CategoryId = 2, ProductName = "Klavye", UnitPrice = 85, UnitsInStock = 1 }

            };
        }

        // üstteki yapı sayesinde programı calıstırdığımızda bizim yerimize bellekte bir yer olusturdu.Bu bize bir veritabanından geliyormuş gibi simüle ediyoruz.
        public void Add(Product product)
        {
            _products.Add(product); //_productsı veritabanımız olarak düşünüyoruz,businessa bir veri geldiğinde bunu _productsa ekliyor.
        }

        public void Delete(Product product)
        {
            // Product productToDelete = null; // referansı olmayan bir değişken oluşturuyorum, sonrasında listemde silmek istediğim id'yi foreach döngüsüyle arayarak buluyorum. Silmek istediğim ürünün referansını productToDelete'in referansına eşitliyorum.

            //foreach (var p in _products)
            //{
            //    if (product.ProductId == p.ProductId)
            //    {
            //        productToDelete = p;
            //    }

            //}

            //LINQ = Language Integrated Query ile yukarıdaki  kodun kısa hali:
           Product productToDelete = _products.SingleOrDefault(p=>p.ProductId == product.ProductId); //bu fonk. _products listemi tek tek dolaşmaya yarar.
            // SingleOrDefault() yerine FirstorDefault() ya da First() de kullanılabilir
            
            _products.Remove(productToDelete);
        }

        public List<Product> GetAll() // businessa ürünlerin listesini gönderme
        {
            return _products; //veritabanının tümünü döndürüyoruz.
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p=> p.CategoryId == categoryId).ToList(); // where, içindeki şarta uyan tüm elemanları yeni bir liste haline getirir ve onu döndürür.

        }

        public void Update(Product product)
        {
            //Gönderdiğim ürün idsine sahip olan ürünü bul demektir.
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}

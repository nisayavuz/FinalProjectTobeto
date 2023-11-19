using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    // Context : veritabanındaki tablolar ile projedeki classları birbirine bağlamak icin kullanılır. Veritabanındaki örn. product ögesini burada product sınıfıyla eslestiririz.
    //Dbcontext: entity framework kurulumuyla beraber gelen base bir sınıftır.
    public class NorthwindContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=nothwind;User ID=postgres;Password=1234;Integrated Security=true;Pooling=true;");
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=northwind; Trusted_Connection=true");
        }

        //   product classı // databasedeki product
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }  
        public DbSet<Order> Orders { get; set; }
    }
}

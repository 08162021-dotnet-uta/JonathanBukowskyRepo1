
using Microsoft.EntityFrameworkCore;
using Project0.StoreApplication.Domain.Abstracts;
using Project0.StoreApplication.Domain.Models;

namespace Project0.StoreApplication.Storage.Adapters
{
    public class DBAdapter : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            var connectionString = System.IO.File.ReadAllText("/home/jon/revature/my_code/data/project_0/config/connection_string.txt");
            //builder.UseSqlServer(@"server=(localdb)\MSSQLLocalDB;database=StoreApplicationDB;Trusted_Connection=True;");
            //builder.UseSqlServer(@"Data Source=172.28.96.1;database=StoreApplicationDB;Integrated Security=True;");
            builder.UseSqlServer(connectionString);
            //builder.UseSqlServer(@"server=172.17.64.1;database=StoreApplicationDB;Trusted_Connection=True;");
        }

    }

    public class StoreAdapter : DBAdapter
    {
        public StoreAdapter() : base()
        {

        }
    }

    public class CustomerAdapter : DBAdapter
    {
        public CustomerAdapter() : base()
        {
        }

    }
}


namespace FinalProject.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class StoreDB : DbContext
    {
        // Your context has been configured to use a 'StoreDB' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'FinalProject.Models.StoreDB' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'StoreDB' 
        // connection string in the application configuration file.
        public StoreDB()
            : base("name=StoreDB")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }    
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Brand> Brands { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}
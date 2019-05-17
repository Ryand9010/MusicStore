using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProject.Models;
using System.Data.Entity;

namespace FinalProject.Models
{
    public class DBInitializer: System.Data.Entity.DropCreateDatabaseAlways<StoreDB>
    {
        protected override void Seed(StoreDB storeDB)
        {
            //const string ImageUrl = "~/Images/placeholder.png";

            var categories = AddCategories(storeDB);
            var brands = AddBrands(storeDB);
            AddProducts(storeDB, categories, brands);
            
                storeDB.SaveChanges();
        }

        private static void AddProducts(StoreDB storeDB, List<Category> categories, List<Brand> brands)
        {
            storeDB.Products.Add(new Product { Name = "Stratocaster", Brand = brands.Single(b => b.Name =="Fender"), Category = categories.Single(c => c.Name == "Electric Guitar"), Description = "Iconic and legendary, the strat is instantly recognizable and a truely classic instrument", Price = 1200});
            storeDB.Products.Add(new Product { Name = "RG1070", Brand = brands.Single(b => b.Name == "Ibanez"), Category = categories.Single(c => c.Name == "Electric Guitar"), Description = "Deep, Dynamic, Versatile sounding bass aimed at the guitarist with a mid to high range budget", Price = 1600 });
            storeDB.Products.Add(new Product { Name = "Les Paul", Brand = brands.Single(b => b.Name == "Gibson"), Category = categories.Single(c => c.Name == "Electric Guitar"), Description = "Classic tone from the famous 1950's, one of the msot popular guitar models ever made", Price = 1600});
            storeDB.Products.Add(new Product { Name = "12C", Brand = brands.Single(b => b.Name == "Taylor"), Category = categories.Single(c => c.Name == "Acoustic Guitar"), Description = "Professional Acoustic Guitar", Price = 950});
            storeDB.Products.Add(new Product { Name = "GS Mini", Brand = brands.Single(b => b.Name == "Martin"), Category = categories.Single(c => c.Name == "Acoustic Guitar"), Description = "Perfect for intermediate level players", Price = 499 });
            storeDB.Products.Add(new Product { Name = "JR1", Brand = brands.Single(b => b.Name == "Yamaha"), Category = categories.Single(c => c.Name == "Acoustic Guitar"), Description = "Perfect for beginner to intermediate level players", Price = 134 });
            storeDB.Products.Add(new Product { Name = "SR500", Brand = brands.Single(b => b.Name == "Ibanez"), Category = categories.Single(c => c.Name == "Bass Guitar"), Description = "Starter Bass Guitar", Price = 350});
            storeDB.Products.Add(new Product { Name = "Jazz Bass", Brand = brands.Single(b => b.Name == "Fender"), Category = categories.Single(c => c.Name == "Bass Guitar"), Description = "Great sounding professional level bass guitar", Price = 1400 });
            storeDB.Products.Add(new Product { Name = "Music Man Stingray", Brand = brands.Single(b => b.Name == "Ernie Ball"), Category = categories.Single(c => c.Name == "Bass Guitar"), Description = "Premium priced professional bass for advanced players", Price = 2149 });
            storeDB.Products.Add(new Product { Name = "Roadshow", Brand = brands.Single(b => b.Name == "Pearl"), Category = categories.Single(c => c.Name == "Drums"), Description = "Starter Acoustic Drum Set", Price = 479 });
            storeDB.Products.Add(new Product { Name = "Accent", Brand = brands.Single(b => b.Name == "Ludwig"), Category = categories.Single(c => c.Name == "Drums"), Description = "Budget friendly 5-piece set", Price = 479 });
            storeDB.Products.Add(new Product { Name = "Renown", Brand = brands.Single(b => b.Name == "Gretsch"), Category = categories.Single(c => c.Name == "Drums"), Description = "Perfect high end drum kit for the working drummer", Price = 1299.99M });
            storeDB.Products.Add(new Product { Name = "Juno", Brand = brands.Single(b => b.Name == "Roland"), Category = categories.Single(c => c.Name == "Keyboard"), Description = "Mid Range Keyboard", Price = 999});
            storeDB.Products.Add(new Product { Name = "Legato", Brand = brands.Single(b => b.Name == "Williams"), Category = categories.Single(c => c.Name == "Keyboard"), Description = "88 key budget Keyboard for the beginner of student", Price = 179.99M });
            storeDB.Products.Add(new Product { Name = "CDP-135", Brand = brands.Single(b => b.Name == "Casio"), Category = categories.Single(c => c.Name == "Keyboard"), Description = "Digital 88 key keyboard with a powerful built in speaker system", Price = 299.99M });
        }

        private static List<Brand> AddBrands(StoreDB storeDB)
        {
            var brands = new List<Brand>
            {
                new Brand { Name = "Fender" },
                new Brand { Name = "Gibson" },
                new Brand { Name = "Ibanez" },
                new Brand { Name = "Taylor" },
                new Brand { Name = "Gretsch" },
                new Brand { Name = "Pearl" },
                new Brand { Name = "Roland" },
                new Brand { Name = "Martin" },
                new Brand { Name = "Epiphone"},
                new Brand { Name = "Yamaha"},
                new Brand {Name = "Ernie Ball"},
                new Brand {Name = "Williams"},
                new Brand {Name = "Casio"},
                new Brand {Name = "Ludwig"}

            };
            brands.ForEach(s => storeDB.Brands.Add(s));
            storeDB.SaveChanges();
            return brands;
        }

        private static List<Category> AddCategories(StoreDB storeDB)
        {
            var categories = new List<Category>
            {
                new Category { Name = "Electric Guitar" },
                new Category { Name = "Acoustic Guitar" },
                new Category { Name = "Bass Guitar" },
                new Category { Name = "Drums" },
                new Category { Name = "Keyboard" },           
            };

            categories.ForEach(s => storeDB.Categories.Add(s));
            storeDB.SaveChanges();
            return categories;
        }
    }
}
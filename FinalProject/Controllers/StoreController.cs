using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    public class StoreController : Controller
    {
        StoreDB storeDB = new StoreDB();
        // GET: Store
        public ActionResult Index()
        {
            var categories = storeDB.Categories.ToList();
            return View(categories);
        }

        public ActionResult Browse( string category)
        {
            var categoryModel = storeDB.Categories.Include("Products").Single(c => c.Name == category);
            return View(categoryModel);
        }

        public ActionResult Details(int id)
        {

            var Item = storeDB.Products.Single(p => p.ProductId == id);
            return View(Item);
        }
    }
}
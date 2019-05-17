using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [DisplayName("Category Name")]
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
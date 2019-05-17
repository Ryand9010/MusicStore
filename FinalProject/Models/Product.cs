using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace FinalProject.Models 
{
    public class Product {
        [ScaffoldColumn(false)]

       
        public int ProductId { get; set; }

        
        public int CategoryId { get; set; }
        

        public int BrandId { get; set; }

        [Required]
        [DisplayName("Product Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Description")]
        public string Description { get; set; }

        [Required]      
        [Range(0.01, 5000.00)]
        [DisplayName("Price")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        //[DisplayName("Image")]
        //public byte[] ImageUrl { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }   
        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}
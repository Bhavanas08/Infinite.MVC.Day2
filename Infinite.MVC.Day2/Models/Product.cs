using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Infinite.MVC.Day2.Models
{
    public class Product
    {
        //public int Id { get; set; }

        //[Required]
        //public string ProductName { get; set; }
        //[Required]
        //public int Price { get; set; }
        //[Required]
        //public int Quantity { get; set; }

        public int Id { get; set; }

        [Required(ErrorMessage ="Product Name cannot be blank")]
        [Display(Name = "Product Name")]
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string ProductName { get; set; }

        [Required]
        [Display(Name = "Product Price")]
        [Range(0, 100000, ErrorMessage ="Price Should be between 0 and 100000")]
        public double Price { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage ="Quantity should be greater than zero")]
        public int Quantity { get; set; }

        //Navigation Properties
        public Category Category { get; set; }//This is not a column

        //ForeignKey
        
        public int CategoryId { get; set; }


        public List<Product> GetProducts()
        {
            return new List<Product> {
            new Product() { Id = 101, ProductName = "Pen", Price = 10, Quantity = 100 },
            new Product() { Id = 102, ProductName = "Bottle", Price = 40, Quantity = 150 },
            new Product() { Id = 103, ProductName = "Book", Price = 20, Quantity = 200 },
            new Product() { Id = 104, ProductName = "Bag", Price = 200, Quantity = 10 }
        };
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bai7.Models
{
    public class CartItem
    {
        public int Id { get; set; }

        public string Title { get; set; }

   
        public string Author { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        [StringLength(100)]
        public string Image { get; set; }
        
        public int Quantity { set; get; }
        public decimal money
        {
            get
            {
                return Quantity * Price;
            }
        }
    }
}
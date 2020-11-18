using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopHere.Models
{
    public class Item
    {

        public int Id { get; set; }
       
        public string ItemName { get; set; }

        public string ItemDescription { get; set; }
        public int Price { get; set; }
        
        public int Quantity { get; set; }

    }
}
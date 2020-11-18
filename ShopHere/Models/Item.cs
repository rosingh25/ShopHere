using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopHere.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
       
        [Required(ErrorMessage ="Enter Name Please")]
        [Display(Name ="Item Name")]
        public string ItemName { get; set; }
        
        [Required(ErrorMessage = "Item Description Required")]
        [StringLength(30,ErrorMessage ="Maximum 30 Characters Allowd")]
        [Display(Name = "Item Description")]

        public string ItemDescription { get; set; }

        [Required(ErrorMessage = "Enter Price Please")]
        [Display(Name = "Item Price")]

        public int Price { get; set; }

        [Required(ErrorMessage = "Quantity Available Required")]
        [Display(Name = "Available Quantity")]
        public int Quantity { get; set; }

    }
}
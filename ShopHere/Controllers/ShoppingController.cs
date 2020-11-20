using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopHere.Models;

namespace ShopHere.Controllers
{
    public class ShoppingController : Controller
    {
        private ApplicationDbContext _context;

        public ShoppingController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Shopping
        public ActionResult Index()
        {
            IEnumerable<Item> AllItems = _context.Items.ToList();
            return View(AllItems);
        }
        public ActionResult ShoppingPage()
        {
            return View();
        }

        /*
         *  -------Customer Actions--------
         *
         */

        public ActionResult SearchItemByCustomer(string search)
        {
            IEnumerable<Item> SearchedItems = (from item in _context.Items
                                              where item.ItemName.Contains(search)
                                              select item).ToList();
            return View("Index", SearchedItems);
        }

        public ActionResult BuyItem(int Id, int Quantity)
        {
            Item BuyItem = _context.Items.SingleOrDefault(m => m.Id == Id);
            if(BuyItem == null)
            {
                return View("InvalidIdView");
            }
            if(BuyItem.Quantity < Quantity)
            {
                return Content("NotAvailable");
            }
            BuyItem.Quantity -= Quantity;
            _context.SaveChanges();
            return View(BuyItem);
        }


        
        
    }
}
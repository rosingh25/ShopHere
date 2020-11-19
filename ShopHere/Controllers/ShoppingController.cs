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


        /*
         *  -------Admin Actions--------
         *
         */

        //Adding Item In View
        public ActionResult AddItemInView()
        {
            Item item = new Item();
            return View(item);
        }

        //To View All Items
        public ActionResult ViewAllItems()
        {
            IEnumerable<Item> AllItems =_context.Items.ToList();
            return View(AllItems);
        }

        //To Add New Item
        public ActionResult AddItemToDb(Item item)
        {
            if (!ModelState.IsValid)
            {
                return View("AddItemInView", item);
            }
            _context.Items.Add(item);
            _context.SaveChanges();
            return View(item);
        }

        //To Edit Item (Using Edit Button)
        public ActionResult EditItemInView(int id)
        {
            Item editing = _context.Items.SingleOrDefault(m => m.Id == id);
            if (editing == null)
            {
                return View("InvalidIdView");
            }
            return View(editing);
        }
        
        //Edit In Database
        public ActionResult EditItemInDb(Item item)
        {
            if (!ModelState.IsValid)
            {
                return View("EditItemInView", item);
            }
            
            _context.Entry(item).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
            return View();

        }

        //Delete Item In Db (Delete Button)
        public ActionResult DeleteItemFromDb(int id)
        {
            Item removing = _context.Items.SingleOrDefault(m => m.Id == id);
            if (removing == null)
            {
                return View("InvalidIdView");
            }
            _context.Items.Remove(removing);
            _context.SaveChanges();
            return View();
        }
    }
}
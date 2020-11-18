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
            return View();
        }
        public ActionResult ShoppingPage()
        {
            return View();
        }
        public ActionResult AddItemInView()
        {
            Item item = new Item();
            return View(item);
        }

        public ActionResult ViewAllItems()
        {
            IEnumerable<Item> AllItems =_context.Items.ToList();
            return View(AllItems);
        }
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
        public ActionResult EditItemInView(int id)
        {
            Item editing = _context.Items.SingleOrDefault(m => m.Id == id);
            if (editing == null)
            {
                return View("InvalidIdView");
            }
            return View(editing);
        }
        
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
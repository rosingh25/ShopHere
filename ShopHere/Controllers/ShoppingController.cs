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
    }
}
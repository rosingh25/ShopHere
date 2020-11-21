using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopHere.Models;
using ShopHere.ViewModels;

namespace ShopHere.Controllers
{
    public class ShoppingController : Controller
    {
        public const byte pageSize = 4;
        public int pageNumberInit = 1;
        private ApplicationDbContext _context;

        public ShoppingController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Shopping
        [AllowAnonymous]
        public ActionResult Index(int? pageNo)
        {
            
            int pageNumber;
            if(TempData["PageNumber"]==null)
            {
                Debug.WriteLine("Entered");
                pageNumber = 1;
                TempData["PageNumber"] = 1;
            }
            else
            {
                if (pageNo == 1)
                {
                    pageNumber = Convert.ToInt32(TempData["PageNumber"]) + 1;
                    TempData["PageNumber"] = pageNumber;
                }
                else if(pageNo == -1)
                {
                    pageNumber = Convert.ToInt32(TempData["PageNumber"]) - 1;
                    TempData["PageNumber"] = pageNumber;
                }
                else
                {
                    pageNumber = 1;
                    TempData["PageNumber"] = pageNumber;
                }
            }
            
            if(pageNumber < 1)
            {
                pageNumber = 1;
                TempData["PageNumber"] = 1;
            }
            pageNumber = (pageNumber - 1) * pageSize;

            IEnumerable<Item> AllItems = _context.Items.OrderBy(item => item.Id).Skip(pageNumber).Take(pageSize).ToList();
            
            Debug.WriteLine(AllItems);
            if(AllItems.Any() == false)
            {

                return Content("Sorry All Products Ended");
            }
            TempData.Keep();
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
        [AllowAnonymous]
        public ActionResult SearchItemByCustomer(string search)
        {
            IEnumerable<Item> SearchedItems = _context.Items.Where(c => c.ItemName.Contains(search)).ToList();

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
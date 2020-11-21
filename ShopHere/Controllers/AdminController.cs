using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopHere.Models;
using ShopHere.ViewModels;

namespace ShopHere.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;


        public AdminController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        /*
         *  -------Admin Actions--------
         *
         */
        public ActionResult SearchItemByCustomerAdmin(string search)
        {
            /* IEnumerable<Item> SearchedItems = (from item in _context.Items
                                               where item.ItemName.Contains(search)
                                               select item).ToList();
            */
            IEnumerable<Item> SearchedItems = _context.Items.Where(c => c.ItemName.Contains(search)).ToList();

            return View("ViewAllItems", SearchedItems);

        }

        //Adding Item In View
        public ActionResult AddItemInView()
        {
            AddItemViewModel addItemModel = new AddItemViewModel
            {
                Categories = _context.Categories.ToList()
            };   
            
            return View(addItemModel);
        }

        //To View All Items
        public ActionResult ViewAllItems()
        {
            IEnumerable<Item> AllItems = _context.Items.ToList();
            return View(AllItems);
        }

        //To Add New Item
        public ActionResult AddItemToDb(AddItemViewModel itemViewModel)
        {
            
            if (!ModelState.IsValid)
            {
                itemViewModel.Categories = _context.Categories.ToList();
                return View("AddItemInView", itemViewModel);
            }
            _context.Items.Add(itemViewModel.Item);
            _context.SaveChanges();
            return View(itemViewModel.Item);
        }

        //To Edit Item (Using Edit Button)
        public ActionResult EditItemInView(int id)
        {
            AddItemViewModel addItemModel = new AddItemViewModel
            {
                Item = _context.Items.Include("Category").SingleOrDefault(m => m.Id == id),
                Categories = _context.Categories.ToList()
            };


            
            if (addItemModel.Item == null)
            {
                return View("InvalidIdView");
            }
            return View(addItemModel);
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
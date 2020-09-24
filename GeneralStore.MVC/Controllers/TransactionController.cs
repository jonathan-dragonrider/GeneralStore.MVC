using GeneralStore.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;


namespace GeneralStore.MVC.Controllers
{
    public class TransactionController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Transaction
        public ActionResult Index()
        {
            var transactions = _db.Transactions.Include(t => t.Customer).Include(t => t.Product);
            return View(transactions);
        }

        // GET: Transaction
        public ActionResult Create()
        {
            // Want the user to input customer full name (how could you make this use login info? probably get into this in ElevenNote), product name, product qty
            // It should get the DateTimeOffset.Now() upon creation - that can go in controller logic?
            // Display existing products?

            // ***Show whether in stock?***

            ViewBag.CustomerId = new SelectList(_db.Customers, "CustomerId", "FullName"); // the soure of dropdownlist

            ViewBag.ProductId = new SelectList(_db.Products, "ProductId", "Name");

            return View();
        }

        // POST: Transaction
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Transaction transaction)
        {
            transaction.CreatedUtc = DateTimeOffset.Now;

            if (ModelState.IsValid)
            {
                _db.Transactions.Add(transaction);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            // This makes it so that even if the user doesn't enter in everything, the already selected dropdowns will stay in the view
            ViewBag.CustomerId = new SelectList(_db.Customers, "CustomerId", "FullName", transaction.CustomerId);
            ViewBag.ProductId = new SelectList(_db.Products, "ProductId", "Name", transaction.ProductId);

            return View(transaction);
        }
    }
}
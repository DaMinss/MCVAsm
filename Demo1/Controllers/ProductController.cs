using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo1.CustomFilters;
using Demo1.Models;

namespace Demo1.Controllers
{
    public class ProductController : Controller
    {
        ProductDbContext ctx;
        public ProductController()
        {
            ctx = new ProductDbContext();
        }

        // GET: Product
       
        [AuthLog(Roles = "Admin")]
        public ActionResult Index()
        {
            var Products = ctx.ProductMasters.ToList();
            return View(Products);
        }
        [AuthLog(Roles = "Admin")]
        //used for calling the create view (i think)
        public ActionResult Create()
        {
            var Product = new ProductMaster();
            return View(Product);
        }

        [HttpPost]
        [AuthLog(Roles = "Admin")]
        public ActionResult Create(ProductMaster p)
        {
            ctx.ProductMasters.Add(p);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [AuthLog(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            //validate if id is correct
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            using(var ctx = new ProductDbContext())
            {
                var product = ctx.ProductMasters.Find(id);
                //find(id) will return null value if it can't find the requested if in the database
                if (product == null){
                    //return user to index page if the id is invalid.
                    return RedirectToAction("Index");
                }
                ctx.ProductMasters.Remove(product);
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
        }


        [AuthLog(Roles = "Sales manager")]
        public ActionResult SaleProduct()
        {
            ViewBag.Message = "This View is designed for the Sales Executive to Sale Product.";
            return View();
        }

    }

}

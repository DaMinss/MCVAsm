using Demo1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using Demo1.CustomFilters;
using System.Data.Entity;

namespace Demo1.Controllers
{
    public class CategoryController : Controller
    {
        CategoryDbcontext context;

        public CategoryController()
        {
            context = new CategoryDbcontext();
        }


        [AuthLog(Roles = "Admin")]
        public ActionResult Index(string search)
        {
            return View(context.Category.Where(x => x.CategoryName.Contains(search) || search == null).ToList());
        }


        [AuthLog(Roles = "Admin")]
        public ActionResult Create()
        {
            var cat = new Category();
            return View(cat);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthLog(Roles = "Admin")]
        public ActionResult Create(Category p)
        {

            context.Category.Add(p);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        //edit button here
        //edit validation
        //edit button here
        //edit validation
        [AuthLog(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            using (var ctx = new CategoryDbcontext())
            {
                var Cat = context.Category.Find(id);
                //find(id) will return null value if it can't find the requested if in the database
                if (Cat == null)
                {
                    //return user to index page if the id is invalid.
                    return RedirectToAction("Index");
                }
                return View(Cat);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthLog(Roles = "Admin")]
        public ActionResult Edit(int? id, Category p)
        {
           
            context.Entry(p).State = EntityState.Modified;
            context.SaveChanges();
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
            using (var ctx = new CategoryDbcontext())
            {
                var Cate = context.Category.Find(id);
                //find(id) will return null value if it can't find the requested if in the database
                if (Cate == null)
                {
                    //return user to index page if the id is invalid.
                    return RedirectToAction("Index");
                }
                context.Category.Remove(Cate);
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [AuthLog(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            using (var ctx = new ProductDbContext())
            {
                var Product = ctx.ProductMasters.Find(id);
                //find(id) will return null value if it can't find the requested if in the database
                if (Product == null)
                {
                    //return user to index page if the id is invalid.
                    return RedirectToAction("Index");
                }
                return View(Product);
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
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.IO;
using System.Web.Mvc;
using Demo1.CustomFilters;
using Demo1.Models;


namespace Demo1.Controllers
{
    public class ProductController : Controller
    {
        ProductDbContext db = new ProductDbContext();

        ProductDbContext ctx;
        public ProductController()
        {
            ctx = new ProductDbContext();
        }

        // GET: Product
       
        [AuthLog(Roles = "Admin")]
        public ActionResult Index(string search)
        {
                return View(db.ProductMasters.Where(x => x.BookName.Contains(search) || search == null).ToList());
           
        }

        [AuthLog(Roles = "Admin")]
        public ActionResult Create()
        {
            var Product = new ProductMaster();
            return View(Product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthLog(Roles = "Admin")]
        public ActionResult Create(ProductMaster p)
        {
            if (p.ImageUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(p.ImageUpload.FileName);
                string extension = Path.GetExtension(p.ImageUpload.FileName);
                fileName = fileName + extension;
                p.Image = "~/Content/Image/" + fileName;
                p.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/Image/"), fileName));
            }
            ctx.ProductMasters.Add(p);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        //edit button here
        //edit validation
        [AuthLog(Roles = "Admin")]
        public ActionResult Edit(int? id)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthLog(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "BookId,BookName,BookCategory,BookPrice")] ProductMaster p)
        {
            if (ModelState.IsValid)
            {
                ctx.Entry(p).State = EntityState.Modified;
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Index");
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
                var Product = ctx.ProductMasters.Find(id);
                //find(id) will return null value if it can't find the requested if in the database
                if (Product == null){
                    //return user to index page if the id is invalid.
                    return RedirectToAction("Index");
                }
                ctx.ProductMasters.Remove(Product);
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

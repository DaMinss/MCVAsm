using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo1.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Demo1.CustomFilters;


namespace Demo1.Controllers
{
    public class ShoppingCartController : Controller
    {
        ProductDbContext _db = new ProductDbContext();
        // GET: ShoppingCart
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if(cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
       [AllowAnonymous]
        public ActionResult AddToCart(int? id)
        {
            var p = _db.ProductMasters.SingleOrDefault(s => s.BookId == id);
            if(p != null)
            {
                GetCart().Add(p);
            }
            return RedirectToAction("ShowToCart", "ShoppingCart");
        }
        public ActionResult ShowToCart(int? id)
        {
            if (Session["Cart"] == null)
                return RedirectToAction("IndexUser", "Product");
            Cart cart = Session["Cart"] as Cart;
            return View(cart);
        }
        public ActionResult Update_Quantity_Cart(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            int id_pro = int.Parse(form["Book_Id"]);
            int quantity = int.Parse(form["Quantity"]);
            cart.Update_Quantity_Shopping(id_pro, quantity);
            return RedirectToAction("ShowToCart", "ShoppingCart");
        }
        public ActionResult RemoveCart(int id)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.Remove_CartItem(id);
            return RedirectToAction("ShowToCart", "ShoppingCart");
        }

    }
}
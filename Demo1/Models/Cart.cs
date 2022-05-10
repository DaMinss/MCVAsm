using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Demo1.Models;

namespace Demo1.Models
{
    //item hang
    public class CartItem
    {
        public ProductMaster _shopping_product { get; set; }
        public int _shopping_quantity { get; set; }
    }
    //gio hang
    public class Cart
    {
        List<CartItem> items = new List<CartItem>();
        public IEnumerable<CartItem> Items
        {
            get { return items; }
        }
        public void Add(ProductMaster p, int _quantity = 1)
        {
            var item = items.FirstOrDefault(s=>s._shopping_product.BookId==p.BookId);
            if (item == null)
            {
                items.Add(new CartItem
                {
                    _shopping_product = p,
                    _shopping_quantity = _quantity
                });
            }
            else
            {
                item._shopping_quantity += _quantity;
            }
        }
        public void Update_Quantity_Shopping(int id, int _quantity)
        {
            var item = items.Find(s => s._shopping_product.BookId == id);
            if (item != null)
            {
                item._shopping_quantity = _quantity;
            }
        }
        public double Total_Money()
        {
            var total = items.Sum(s => s._shopping_product.BookPrice * s._shopping_quantity);
            return (double)total;
        }
        public void Remove_CartItem(int id)
        {
            items.RemoveAll(s => s._shopping_product.BookId == id);
        }
        
    }
}
using ASM7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASM7.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public List<CartItem> GetCartItems() { 
            List<CartItem> cartItems = Session["gh"] as List<CartItem>;
            if(cartItems == null)
            {
                cartItems = new List<CartItem>();
                Session["gh"] = cartItems;
            }    
            return cartItems;

        }

        public ActionResult Index()
        {
            List<CartItem> cartItems = GetCartItems();
            if(cartItems.Count==0)

                 return RedirectToAction("Index","Books");
            ViewBag.Tongsoluong = cartItems.Sum(p => p.Quantity);
            ViewBag.Tongtien = cartItems.Sum(p => p.Quantity * p.Price);
            return View(cartItems);
        }
    }
}
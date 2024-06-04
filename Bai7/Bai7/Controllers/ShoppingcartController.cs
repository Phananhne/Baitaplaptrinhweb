using Bai7.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;

namespace Bai7.Controllers
{
    public class ShoppingcartController : Controller
    {
        public List<CartItem> Getcartitem()
        {
            List<CartItem> cartItems = Session["gh"] as List<CartItem>;
            if(cartItems == null)
            {
                cartItems = new List<CartItem>();
                Session["gh"] = cartItems;
            }
            return cartItems;
        }
        public ActionResult CartSummary()
        {
            List<CartItem> cartItems = Getcartitem();
            ViewBag.CartCount = cartItems.Count();
            return PartialView();
        }
        // GET: Shoppingcart
        public ActionResult Index()
        {
            
            List<CartItem> cartItems = Getcartitem();
            ViewBag.Tongtien = cartItems.Sum(p=>p.money);
            ViewBag.Tongsoluong = cartItems.Sum(p => p.Quantity);
            return View(cartItems);
        }
        public ActionResult AddToCart(int bookid)
        {
            List<CartItem> cartItems = Getcartitem();
            CartItem findCartItem = cartItems.FirstOrDefault(p=>p.Id == bookid);   
            if(findCartItem == null)
            {
                BookDBModel context = new BookDBModel();
                findCartItem = new CartItem();
               Book findBook = context.Books.FirstOrDefault(p=>p.Id == bookid);
                findCartItem.Id = bookid;
                findCartItem.Title = findBook.Title;
                findCartItem.Price = findBook.Price.Value;
                findCartItem.Image = findBook.Image;
                findCartItem.Quantity = 1;
                cartItems.Add(findCartItem);

            }
            else
            {
                findCartItem.Quantity++;
            }
            return RedirectToAction("Index");
        }
       public RedirectToRouteResult UpdateCart(int id, int txtQuantity)
        {
            List<CartItem> cartItems = Getcartitem();
            CartItem findCartItem = cartItems.FirstOrDefault(p => p.Id == id);
            if(findCartItem != null) 
               findCartItem.Quantity= txtQuantity;
            return RedirectToAction("Index");
        }
        public ActionResult Order()
        {
            List<CartItem> cartItems = Getcartitem();
            int currentUserId = 123;//thực chất phải lấy từ login
            using (var context = new BookDBModel())
            {
                using (DbContextTransaction transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        //insert order
                        Order newOrder = new Order()
                        {
                            CustomerId = currentUserId,
                            OrderDate = DateTime.Now,
                            DeliveryDate = DateTime.Now,
                            isComplete = "false",
                            isPaid = "false"


                        };
                        newOrder = context.Orders.Add(newOrder);
                        
                        context.SaveChanges();
                       
                        foreach (var item in cartItems)
                        {
                            OrderDetail detail = new OrderDetail()
                            {
                                OrderNo = newOrder.OrderNo,
                                BookId = item.Id,
                                Quantity = item.Quantity,
                                Price = item.Price,
                                

                            };
                            context.OrderDetails.Add(detail);
                            context.SaveChanges();
                        }
                       
                        transaction.Commit();

                        //insert Orderdetail

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return Content("Đã xảy ra lỗi trong quá trình đặt hàng.....");
                    }
                }
                }
            Session["Giỏ hàng"] = null;
            return RedirectToAction("ConfrimOrder","ShoppingCart");
         }
        public ActionResult ConfrimOrder()
        {
            return View();
        }



        }
    }

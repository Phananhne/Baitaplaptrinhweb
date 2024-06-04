using Bai6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bai6.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            var context = new BookModelContext();
            return View(context.Books.ToList());
        }
        public ActionResult GetBookByCategory(int id)
        {
            var context = new BookModelContext();
            return View("Index", context.Books.Where(p => p.CategoryId == id).ToList());
        }
        public ActionResult GetCategory()
        {
            var context = new BookModelContext();
            var listCategory = context.Categories.ToList();
            return PartialView(listCategory);
        }
        public ActionResult Details(int id)
        {
            var context = new BookModelContext();
            var firstBook = context.Books.FirstOrDefault(p => p.Id == id);
            if (firstBook == null)
                return HttpNotFound("Không tìm thấy mã sách này!");
            return View(firstBook);
        }
        [Authorize]
        public ActionResult AddToCart(int id)
        {
            return Content("thêm thành công!!");
        }
    }
}
using ASM6.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.UI;

namespace ASM6.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        // GET: Book
        public ActionResult Index()
        {
            var context = new BookContextModel();
            return View(context.Books.ToList());
        }
        public ActionResult GetBookByCategory(int id)
        {
            var context = new BookContextModel();
            return View("Index", context.Books.Where(p => p.CategoryId == id).ToList());
        }
        public ActionResult GetCategory()
        {
            var context = new BookContextModel();
            var listCategory = context.Categories.ToList();
            return PartialView(listCategory);
        }
        public ActionResult Details(int id)
        {
            var context = new BookContextModel();
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
        // Lớp đại diện cho người dùng (user)
      /*  public class ApplicationUser : IdentityUser
        {
            // Thêm thuộc tính UserName
            public string UserName { get; set; }
        }

        // Lớp đại diện cho DbContext

            public static ApplicationDbContext Create()
            {
                return new ApplicationDbContext();
            }

        // Lớp đăng ký (register) người dùng
             protected void CreateUser_Click(object sender, EventArgs e)
            {
                var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
                var userManager = new UserManager<ApplicationUser>(userStore);

                var user = new ApplicationUser
                {
                    UserName = UserName.Text,
                    Email = Email.Text
                };

                var result = userManager.Create(user, PasswordHashPasswordHash.Text);

                if (result.Succeeded)
                {
                    // Đăng nhập ngay sau khi đăng ký thành công
                    SignInManager<ApplicationUser, string> signInManager = new SignInManager<ApplicationUser, string>(userManager, Context.GetOwinContext().Authentication);
                    signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);

                    // Chuyển hướng tới trang chủ
                    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                }
                else
                {
                    ErrorMessage.Text = result.Errors.FirstOrDefault();
                }
            }
        }*/
    }
}

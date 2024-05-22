using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DinhCongMinh_QuanLySinhVien_CuoiKy.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        // Action method to handle login form submission
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            // Check username and password
            if (IsValidUser(username, password))
            {
                // Authentication successful, set authentication cookie
                FormsAuthentication.SetAuthCookie(username, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Authentication failed, return to login page with error message
                ViewBag.ErrorMessage = "Invalid username or password.";
                return View();
            }
        }

        // Action method to handle logout
        public ActionResult Logout()
        {
            // Log out the user by removing authentication cookie
            FormsAuthentication.SignOut();
            Response.Cookies.Clear();
            Session.Clear();
            return RedirectToAction("Login", "Account");
        }

        // Dummy method to validate user (replace with actual authentication logic)
        private bool IsValidUser(string username, string password)
        {
            // Replace this with your actual user authentication logic
            return (username == "admin" && password == "123");
        }
    }
}
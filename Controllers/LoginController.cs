using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MinesweeperWeb.Models;
//Emily Quevedo and Almicke Navarro 
//CST 247
//Milestone 1
//January 23, 2019
//This is our own work, with help from http://www.dotnetlearners.com/blogs/view/124/login-page-example-in-mvc-using-entity-frame-work.aspx

namespace MinesweeperWeb.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Authenticate(user userModel)
        {
            //using the database
            using (minesweeperWebEntities db = new minesweeperWebEntities())
            {
                //checks database table names users for username and password 
                var userDetails = db.users.Where(x => x.username == userModel.username && x.password == userModel.password).FirstOrDefault();
                //error message is displayed if username/password was not found in database
                if (userDetails == null)
                {
                    userModel.LoginErrorMessage = "Wrong username or password";
                    return View("Index", userModel);
                }
                //redirects user to login success page and displays username
                else
                {
                    Session["userID"] = userDetails.id;
                    Session["username"] = userDetails.username;
                    return RedirectToAction("Index", "HomePage");
                }
            }
        }
        //allows user to logout
        public ActionResult Logout()
        {
            int userID = (int)Session["userID"];
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}
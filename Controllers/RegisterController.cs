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
//With help of https://www.c-sharpcorner.com/article/registration-form-with-asp-net-mvc/

namespace MinesweeperWeb.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Create(int id = 0)
        {
            user userModel = new user();
            return View(userModel);
        }

        [HttpPost]
        //receives input from user 
        public ActionResult Create(user userModel)
        {
            using (minesweeperWebEntities db = new minesweeperWebEntities())
            {
                //if username already exists in database, user is notified 
                if (db.users.Any(x => x.username == userModel.username))
                {
                    userModel.RegisterFail = "Username already exists";
                    return View("Create", userModel);
                }
                //otherwise, the new user is added into the database and saved
                db.users.Add(userModel);
                db.SaveChanges();
            }
            //clears the model state object and redirects user to a success view
            ModelState.Clear();
            Session["username"] = userModel.username;
            return RedirectToAction("Index", "RegisterSuccess");
        }
    }
}
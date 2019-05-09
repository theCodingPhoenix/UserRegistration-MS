using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserRegistrationProject.Models;

namespace UserRegistrationProject.Controllers
{
    public class UserRegController : Controller
    {
        // GET: UserRegDB
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserRegDB/Details/5
        public ActionResult Details(int id)
        {
            UserRegDBHandle dbhandle = new UserRegDBHandle();
            ModelState.Clear();
            return View(dbhandle.GetUserList());
        }

        // GET: UserRegDB/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserRegDB/Create
        [HttpPost]
        public ActionResult Create(UserDetail umodel)
        {
                try
                {
                    if (ModelState.IsValid)
                    {
                        UserRegDBHandle sdb = new UserRegDBHandle();
                        if (sdb.AddNewUser(umodel))
                        {
                            ViewBag.Message = "User Details Added Successfully";
                            ModelState.Clear();
                        }
                    }
                    return View();
                }
                catch
                {
                    return View();
         
                }            
        }

        // GET: UserRegDB/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserRegDB/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserRegDB/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserRegDB/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

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
            UserRegDBHandle dbhandle = new UserRegDBHandle();
            ModelState.Clear();
            return View(dbhandle.GetUserList());
        }

        // GET: UserReg/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserReg/Create
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
                ViewBag.Message = "Something went wrong";
                    return View();
         
                }            
        }

    }
}

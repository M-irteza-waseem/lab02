using HF_super_mart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HF_super_mart.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Login(Employee objuser)
        {

            HF_SUPER_MARTEntities1 obj = new HF_SUPER_MARTEntities1();
            var user = obj.Employees.Where(x => x.Email == objuser.Email && x.Password == objuser.Password).FirstOrDefault();
            try
            {
                Session["Name"] = user.First_Name;
            }
            catch (Exception)
            {


            }
            if (user != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
    }
}
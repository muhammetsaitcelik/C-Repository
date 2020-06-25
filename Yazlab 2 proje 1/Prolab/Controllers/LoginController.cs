using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;
using System.Web.Mvc;
using Prolab.Models;

namespace Prolab.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Autherize(Prolab.Models.User userModel)
        {
            using (LoginDataEntities1 db = new LoginDataEntities1())
            {
                var userDetails = db.User.Where(x => x.Username == userModel.Username && x.Password == userModel.Password).FirstOrDefault();
                if (userDetails == null)
                {
                    userModel.LoginErrorMassage = "Username yada Password yanlış girildi.";
                    return View("Index",userModel);
                }

                else                {
                    Session.Add("UserID", userDetails.UserID);
                    Session.Add("username", userDetails.Username);                               
                    return RedirectToAction("index","home1");
                }

            }

        }
     
        public ActionResult Kullanıcıgiris()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

    }
}
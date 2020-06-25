using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prolab.Models;

namespace Prolab.Controllers
{
    public class Login2Controller : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Autherize(Prolab.Models.admin AdminModel)
        {
            using (LoginDataEntities1 db = new LoginDataEntities1())
            {
                var userDetails = db.admin.Where(x => x.Admin1 == AdminModel.Admin1 && x.Password == AdminModel.Password).FirstOrDefault();
                if (userDetails == null)
                {
                    AdminModel.LoginErrorMassage = "Username yada Password yanlış girildi.";
                    return View("Index", AdminModel);
                }

                else
                {
                    Session["AdminID"] = userDetails.AdminID;
                    Session["username"] = userDetails.Admin1;
                    return RedirectToAction("Index", "Home2");
                }

            }

        }

        public ActionResult Yöneticigiris()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login2");
        }
    }
}
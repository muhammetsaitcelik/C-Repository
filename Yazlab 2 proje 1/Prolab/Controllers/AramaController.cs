using Prolab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prolab.Controllers
{
    public class AramaController : Controller
    {
        LoginDataEntities1 db = new LoginDataEntities1();
        // GET: Arama
        public ActionResult Index(string searching)
        {
            return View(db.Book.Where(x=> x.Bookname.Contains(searching) || searching== null).ToList());
        }
    }
}
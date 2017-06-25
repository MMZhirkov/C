using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private Models.ShopDBEntities db = new Models.ShopDBEntities();
        public ActionResult Index()
        {
            var Items = db.Cars;
            return View(Items);
        }
        public ActionResult CarPage(int item_id)
        {
            var Item = db.Cars.FirstOrDefault(x => x.Id == item_id);
            return View(Item);
        }
    }
}
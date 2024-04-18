using Microsoft.AspNetCore.Mvc;
using MvcTraining.Models;

namespace MvcTraining.Controllers
{
    public class SatisController : Controller
    {
        MvcDbStokContext db;
        public SatisController()
        {
            db = new MvcDbStokContext();
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult YeniSatis()
        {
            return View();
        }
        [HttpPost] 
        public IActionResult YeniSatis(Tblsatislar p1)
        {
            db.Tblsatislars.Add(p1);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

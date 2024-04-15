using Microsoft.AspNetCore.Mvc;
using MvcTraining.Models;

namespace MvcTraining.Controllers
{
    public class MusteriController : Controller
    {
        MvcDbStokContext db;
        public MusteriController() 
        { 
            db = new MvcDbStokContext();
        }

        public IActionResult Index()
        {
            var degerler = db.Tblmusterilers.ToList();
            return View(degerler);
        }

        [HttpGet]
        public IActionResult YeniMusteri()
        {
            return View();
        }

        [HttpPost]
        public IActionResult YeniMusteri(Tblmusteriler p1)
        {
            if(!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.Tblmusterilers.Add(p1);
            db.SaveChanges();
            return View();
        }

        public IActionResult Sil(int id)
        {
            var musteri = db.Tblmusterilers.FirstOrDefault(x => x.Musteriid == id);
            db.Tblmusterilers.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult MusteriGetir(int id) 
        {
            var musteri = db.Tblmusterilers.FirstOrDefault(x => x.Musteriid == id);
            return View("MusteriGetir",musteri);
        }

        public IActionResult Guncelle(Tblmusteriler p1) 
        {
            var musteri = db.Tblmusterilers.FirstOrDefault(x => x.Musteriid == p1.Musteriid);
            musteri.Musteriad = p1.Musteriad;
            musteri.Musterisoyad = p1.Musterisoyad;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

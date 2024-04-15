using Microsoft.AspNetCore.Mvc;
using MvcTraining.Models;

namespace MvcTraining.Controllers
{
    public class KategoriController : Controller
    {
        MvcDbStokContext db;
        
        public KategoriController()
        {
            db = new MvcDbStokContext();
        }

        public IActionResult Index()
        {
            var degerler = db.Tblkategorilers.ToList();
            return View(degerler);
        }

        [HttpGet]
        public IActionResult YeniKategori()
        {
            return View();
        }

        [HttpPost]
        public IActionResult YeniKategori(Tblkategoriler p1)
        {
            if(!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.Tblkategorilers.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");  
        }
        public IActionResult Sil(int id)
        {
            var kategori = db.Tblkategorilers.FirstOrDefault(x=>x.Kategoriid == id);

            if(kategori != null)
            {
                db.Tblkategorilers.Remove(kategori);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult KategoriGetir(int id)
        {
            var ktgr = db.Tblkategorilers.FirstOrDefault(x=>x.Kategoriid == id);
            return View("KategoriGetir",ktgr);
        }

        public IActionResult Guncelle(Tblkategoriler p1)
        {
            var ktg = db.Tblkategorilers.FirstOrDefault(x=>x.Kategoriid == p1.Kategoriid);
            ktg.Kategoriad = p1.Kategoriad;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

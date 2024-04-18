using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcTraining.Models;
using X.PagedList;

namespace MvcTraining.Controllers
{
    public class UrunController : Controller
    {
        MvcDbStokContext db;
        public UrunController() 
        { 
            db = new MvcDbStokContext();
        }
        public IActionResult Index(int sayfa=1)
        {       
            var degerler = db.Tblurunlers.ToPagedList(sayfa,10);
        
            foreach (var urun in degerler)
            {
                db.Entry(urun).Reference(u => u.UrunkategoriNavigation).Load();
            }

            return View(degerler);
        }

        public IActionResult Search(string p)
        {
            var degerler = from d in db.Tblurunlers select d;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.Urunad.Contains(p));
            }
            var resultList = degerler.ToList();
            return View(resultList);
        }

        [HttpGet]
        public IActionResult YeniUrun()
        {
            List<SelectListItem> degerler = (from i in db.Tblkategorilers.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.Kategoriad,
                                                 Value = i.Kategoriid.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }

        [HttpPost]
        public IActionResult YeniUrun(Tblurunler p1)
        {
            if (p1.UrunkategoriNavigation != null)
            {
                var ktg = db.Tblkategorilers.FirstOrDefault(m => m.Kategoriid == p1.UrunkategoriNavigation.Kategoriid);
                p1.UrunkategoriNavigation = ktg;
                db.Tblurunlers.Add(p1);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Sil(int id)
        {
            var ürün = db.Tblurunlers.FirstOrDefault(x=> x.Urunid == id);

            if(ürün != null)
            {
                db.Tblurunlers.Remove(ürün); 
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult UrunGetir(int id)
        {
            List<SelectListItem> degerler = (from i in db.Tblkategorilers.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.Kategoriad,
                                                 Value = i.Kategoriid.ToString()
                                             }).ToList();
            var urun = db.Tblurunlers.FirstOrDefault(x => x.Urunid == id);
            ViewBag.dgr = degerler;

            return View("UrunGetir", urun);
        }

        public IActionResult Guncelle(Tblurunler p1)
        {
            var urun = db.Tblurunlers.FirstOrDefault(x => x.Urunid == p1.Urunid);
            urun.Urunad = p1.Urunad;
            urun.Stok = p1.Stok;
            urun.Marka = p1.Marka;
            urun.Fiyat = p1.Fiyat;

            var ktg = db.Tblkategorilers.FirstOrDefault(m => m.Kategoriid == p1.UrunkategoriNavigation.Kategoriid);
            urun.Urunkategori = ktg.Kategoriid;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

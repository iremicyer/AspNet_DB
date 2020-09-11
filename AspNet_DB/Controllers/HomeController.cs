using AspNet_DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNet_DB.Controllers
{
    public class HomeController : Controller
    {
        List<KayitModel> kayitListe = new List<KayitModel> {
            new KayitModel(){ kayId=1 , adsoyad= "Ali Can" , yas=10 , adres = "Nişantaş Mahallesi/Konya"},
            new KayitModel(){ kayId=2 , adsoyad= "Firdevs Ilgaz" , yas=25 , adres = "Demir Mahallesi/Konya"},
            new KayitModel(){ kayId=3 , adsoyad= "İrem İçyer" , yas=20 , adres = "Rauf Denktaş Caddesi/Konya"},
            new KayitModel(){ kayId=4 , adsoyad= "Uygar Doğan" , yas=5 , adres = "Şefikcan Caddesi/Konya"},
            new KayitModel(){ kayId=5 , adsoyad= "Zeynep Bilge" , yas=1 , adres = "Barış Caddesi/Konya"},
            new KayitModel(){ kayId=6 , adsoyad= "Yaşar içyer" , yas=56 , adres = "Altıparmak Caddesi/Bursa"},
        };
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Kayitlar() // kayıt yapma eylemini gerçekleştirecek kısım.
        {
            return View(kayitListe); // yukarıdaki KayitListe nesnesini burada kullanıyoruz.
        }
        public ActionResult Detay(int? ıd)
        {
            var kayit = kayitListe.Where(k => k.kayId == ıd).SingleOrDefault();
            /* eğer dizi içinden sadece bir tane veri almak istiyorsak ve seçim şartı sağlanmıyorsa,bu durumda int tipinin varsayılan değeri olan 0 döndürülsün istiyorsak singleordefault kullanırız.*/
            if (kayit != null)
            {
                return View(kayit);
            }
            else
            {
                return RedirectToAction("Kayitlar"); // RedirectToAction yöntemi ile MVC'de HTML olmadan belirtilen Action'ın çalışması sağlanır.(bir çeşit yönlendirmedir)
            }
        }
        public ActionResult Hesapla()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Hesapla(FormCollection frm)
        {

            double vnot = Convert.ToDouble(frm["vNot"].ToString());
            double unot = Convert.ToDouble(frm["uNot"].ToString());
            double fnot = Convert.ToDouble(frm["fNot"].ToString());

            double ort = (vnot * 0.3) + (unot * 0.1) + (fnot * 0.6);

            if (ort < 60)
            {
                ViewBag.ortalama = ort.ToString(); //ViewBag Controller'da oluşturulan bir yapıyı View kısmına taşımak için kullanılır.(Birden fazla yapı aktarılabilir)
                ViewBag.sonuc = "KALDI";
                ViewBag.cl = "alert alert-danger"; // "alert alert-danger" kapatma düğmesi oluşturur
            }
            else
            {
                ViewBag.ortalama = ort.ToString(); //ViewBag Controller'da oluşturulan bir yapıyı View kısmına taşımak için kullanılır.(Birden fazla yapı aktarılabilir)
                ViewBag.sonuc = "GEÇTİ";
                ViewBag.cl = "alert alert-success"; // "alert alert-danger" kapatma düğmesi oluşturur
            }

            return View();
        }
    }
}
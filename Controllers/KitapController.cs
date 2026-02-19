using Microsoft.AspNetCore.Mvc;
using kapsamlıkitapcont.Models; 

namespace kapsamlıkitapcont.Controllers
{
    public class KitapController : Controller
    {
       
        private static List<Kitap> Kitaplar = new List<Kitap>
        {
            new Kitap { Id = 1, Ad = "Sefiller", Yazar = "Victor Hugo", YayinYili = 1862 },
            new Kitap { Id = 2, Ad = "Suç ve Ceza", Yazar = "Dostoyevski", YayinYili = 1866 },
            new Kitap { Id = 3, Ad = "Yüzüklerin Efendisi", Yazar = "J.R.R. Tolkien", YayinYili = 1954 },
            new Kitap { Id = 4, Ad = "Harry Potter ve Felsefe Taşı", Yazar = "J.K. Rowling", YayinYili = 1997 },
            new Kitap { Id = 5, Ad = "Simyacı", Yazar = "Paulo Coelho", YayinYili = 1988 },
            new Kitap { Id = 6, Ad = "Kürk Mantolu Madonna", Yazar = "Sabahattin Ali", YayinYili = 1943 },
        };

        
        public IActionResult Index()
        {
            return View(Kitaplar);
        }

        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Kitap kitap)
        {
            kitap.Id = Kitaplar.Max(x => x.Id) + 1;

            Kitaplar.Add(kitap);

            return RedirectToAction("Index");
        }

        
        public IActionResult Edit(int id)
        {
            var kitap = Kitaplar.FirstOrDefault(x => x.Id == id);
            return View(kitap);
        }

        [HttpPost]
        public IActionResult Edit(Kitap guncel)
        {
            var kitap = Kitaplar.FirstOrDefault(x => x.Id == guncel.Id);

            if (kitap != null)
            {
                kitap.Ad = guncel.Ad;
                kitap.Yazar = guncel.Yazar;
                kitap.YayinYili = guncel.YayinYili;
            }

            return RedirectToAction("Index");
        }

        
        public IActionResult Delete(int id)
        {
            var kitap = Kitaplar.FirstOrDefault(x => x.Id == id);

            if (kitap != null)
                Kitaplar.Remove(kitap);

            return RedirectToAction("Index");
        }
    }
}

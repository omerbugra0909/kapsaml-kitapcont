
using Microsoft.AspNetCore.Mvc;
using kapsamlıkitapcont.Models;

namespace kapsamlıkitapcont.Controllers;

public class OgrenciController : Controller
{
    
    private static List<Ogrenci> Ogrenciler = new List<Ogrenci>
    {
        new Ogrenci { Id = 1, Ad = "Ahmet", Soyad = "Yılmaz", Yas = 20 },
        new Ogrenci { Id = 2, Ad = "Ayşe", Soyad = "Demir", Yas = 22 },
        new Ogrenci { Id = 3, Ad = "Mehmet", Soyad = "Kara", Yas = 19 },
        new Ogrenci { Id = 4, Ad = "Elif", Soyad = "Çelik", Yas = 21 },
        new Ogrenci { Id = 5, Ad = "Can", Soyad = "Öztürk", Yas = 23 },
        new Ogrenci { Id = 6, Ad = "Zeynep", Soyad = "Aydın", Yas = 20 }
    };

    
    public IActionResult Index()
    {
        return View(Ogrenciler);
    }

    
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Ogrenci ogrenci)
    {
        ogrenci.Id = Ogrenciler.Max(x => x.Id) + 1;

        Ogrenciler.Add(ogrenci);

        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
        var ogrenci = Ogrenciler.FirstOrDefault(x => x.Id == id);
        return View(ogrenci);
    }

    [HttpPost]
    public IActionResult Edit(Ogrenci guncel)
    {
        var ogrenci = Ogrenciler.FirstOrDefault(x => x.Id == guncel.Id);

        if (ogrenci != null)
        {
            ogrenci.Ad = guncel.Ad;
            ogrenci.Soyad = guncel.Soyad;
            ogrenci.Yas = guncel.Yas;
        }

        return RedirectToAction("Index");
    }

    
    public IActionResult Delete(int id)
    {
        var ogrenci = Ogrenciler.FirstOrDefault(x => x.Id == id);

        if (ogrenci != null)
            Ogrenciler.Remove(ogrenci);

        return RedirectToAction("Index");
    }
}


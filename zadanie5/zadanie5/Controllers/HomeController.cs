using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using zadanie5.Models;
using zadanie5.ViewModels;

namespace zadanie5.Controllers
{
    public class HomeController : Controller
    {
        AlbumContext db;
        public HomeController(AlbumContext context)
        {
            db = context;
        }
        public IActionResult Index(int? singerId)
        {
            // формируем список компаний для передачи в представление
            List<Singer> singerModels = db.Singers
                //              .Select(c => new BrandModel { Id = c.Id, Name = c.Name })

                .ToList();
            // добавляем на первое место
            singerModels.Insert(0, new Singer { Id = 0, Name = "All", Birthdate = "01.01.01" });

            List<Album> _albums = db.Albums.ToList();
            ViewBag.Singers = singerModels;
            IndexViewModel ivm = new IndexViewModel { Singers = singerModels, Albums = _albums };

            // если передан id компании, фильтруем список
            if (singerId != null && singerId > 0)
                ivm.Albums = db.Albums.Where(p => p.Pevets.Id == singerId);

            return View(ivm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddNewSinger()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNewSinger(string submit, string cancel, Singer singer)
        {
            var button = submit ?? cancel;
            if (button == "Cancel")
            {
                return RedirectToAction("AddNewSinger");
            }

            if (db.Singers.Any(x => x.Name == singer.Name))
            {
                return BadRequest();
            }

            db.Singers.Add(singer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
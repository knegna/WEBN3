using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using zadanie4.Models;

namespace zadanie4.Controllers
{
    public class AlbumController: Controller
    {
        AlbumContext db;
        public AlbumController(AlbumContext context)
        {
            db = context;
        }

        public IActionResult Album(string? text)
        {
            if (text != null && text.Trim() != "")
            {
                var albums = db.Albums
                .Where(c => c.Name.Contains(text) ||
                    c.ColSongs.ToString().Contains(text) ||
                    c.Date.Contains(text));

                return View(albums);
            }
            else
            {
                return View(db.Albums.ToList());
            }
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Album album)
        {
            db.Albums.Add(album);
            db.SaveChanges();
            return View();
        }

        public IActionResult Detail(int? ID)
        {
            if (ID == null)
            {
                return new BadRequestResult();
            }
            Album album = db.Albums.Find(ID);
            if (album == null)
            {
                return new NotFoundResult();
            }
            ViewBag.Name = album.Name;
            ViewBag.Id = album.Id;
            ViewBag.ColSongs = album.ColSongs;
            ViewBag.Date = album.Date;

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int? ID)
        {
            if (ID == null)
            {
                return new BadRequestResult();
            }
            Album album = db.Albums.Find(ID);
            if (album == null)
            {
                return new NotFoundResult();
            }
            ViewBag.Name = album.Name;
            ViewBag.Id = album.Id;
            ViewBag.ColSongs = album.ColSongs;
            ViewBag.Date = album.Date;

            return View();
        }

        [HttpPost]
        public IActionResult Edit(Album album)
        {
            if (album == null)
            {
                return new BadRequestResult();
            }

            Album albumtemp = db.Albums.Find(album.Id);
            albumtemp.Name = album.Name;
            albumtemp.Id = album.Id;
            albumtemp.ColSongs = album.ColSongs;
            albumtemp.Date = album.Date;
            db.SaveChanges();

            return Redirect("/Album/Album");
        }

        public IActionResult Delete(int? ID)
        {
            if (ID == null)
            {
                return new BadRequestResult();
            }
            Album album = db.Albums.Find(ID);
            if (album == null)
            {
                return new NotFoundResult();
            }
            db.Albums.Remove(db.Albums.Find(ID));
            db.SaveChanges();
            return Redirect("/Album/Album");
        }
    }
}

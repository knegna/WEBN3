using System;
using System.Collections.Generic;
using System.Linq;
using zadanie4.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Web;
using Microsoft.AspNetCore.Http;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace zadanie4.Controllers
{
    public class SingerController : Controller
    {
        AlbumContext db;
        public SingerController(AlbumContext context)
        {
            db = context;
        }

        public IActionResult Singer(string? text)
        {
            if (text != null && text.Trim() != "")
            {
                var singer = db.Singers
                .Where(c => c.Firstname.Contains(text) ||
                    c.Lastname.Contains(text) ||
                    c.Birthdate.Contains(text));

                return View(singer);
            }
            else
            {
                return View(db.Singers.ToList());
            }
        }

       
        

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Singer singer)
        {
            db.Singers.Add(singer);
            db.SaveChanges();
            return View();
        }

        public IActionResult Detail(int? ID)
        {
            if (ID == null)
            {
                return new BadRequestResult();
            }
            Singer singer = db.Singers.Find(ID);
            if (singer == null)
            {
                return new NotFoundResult();
            }
            ViewBag.Firstname = singer.Firstname;
            ViewBag.Id = singer.Id;
            ViewBag.Lastname = singer.Lastname;
            ViewBag.Birthdate = singer.Birthdate;

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int? ID)
        {
            if (ID == null)
            {
                return new BadRequestResult();
            }
            Singer singer = db.Singers.Find(ID);
            if (singer == null)
            {
                return new NotFoundResult();
            }
            ViewBag.Firstname = singer.Firstname;
            ViewBag.Id = singer.Id;
            ViewBag.Lastname = singer.Lastname;
            ViewBag.Birthdate = singer.Birthdate;

            return View();
        }

        [HttpPost]
        public IActionResult Edit(Singer singer)
        {
            if (singer == null)
            {
                return new BadRequestResult();
            }

            Singer tempsinger = db.Singers.Find(singer.Id);
            tempsinger.Firstname = singer.Firstname;
            tempsinger.Id = singer.Id;
            tempsinger.Lastname = singer.Lastname;
            tempsinger.Birthdate = singer.Birthdate;
            db.SaveChanges();

            return Redirect("/Singer/Singer");
        }

        public IActionResult Delete(int? ID)
        {
            if (ID == null)
            {
                return new BadRequestResult();
            }
            Singer singer = db.Singers.Find(ID);
            if (singer == null)
            {
                return new NotFoundResult();
            }
            db.Singers.Remove(db.Singers.Find(ID));
            db.SaveChanges();
            return Redirect("/Singer/Singer");
        }
    }
}

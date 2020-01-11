using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using _6_4.Models;

namespace _6_4.Controllers
{
    public class HomeController : Controller
    {
        AlbumStoreContext db;

        public HomeController(AlbumStoreContext context)
        {
            db = context;
            if (db.Singers.Count() == 0)
            {
                Singer EdSheeran = new Singer { Name = "EdSheeran", Birthdate = "10.10.2000" };
                Singer Adelle = new Singer { Name = "Adelle", Birthdate = "15.01.1999" };
                Singer MJaskon = new Singer { Name = "MichaleJackson", Birthdate = "07.02.1989" };
                Singer NBHD = new Singer { Name = "The Neighbourhood", Birthdate = "09.10.1985" };

                if (!context.Singers.Any())
                {
                    context.Singers.AddRange(EdSheeran, Adelle, MJaskon, NBHD);
                    context.SaveChanges();
                }
                if (!context.Albums.Any())
                {
                    context.Albums.AddRange(
                        new Album
                        {
                            Singer = EdSheeran,
                            Date = "14.02.15",
                            Name = "Love"
                        },
                        new Album
                        {
                            Singer = Adelle,
                            Name = "heart",
                            Date = "18.09.19"
                        },
                        new Album
                        {
                            Singer = MJaskon,
                            Name = "Sing",
                            Date = "09.08.17"
                        },
                        new Album
                        {
                            Singer = EdSheeran,
                            Name = "Dance",
                            Date = "2.12.18"
                        },
                        new Album
                        {
                            Singer = NBHD,
                            Name = "Grey",
                            Date = "03.02.2018"
                        },
                        new Album
                        {
                            Singer = NBHD,
                            Name = "Black",
                            Date = "18.08.2015"
                        }
                        );
                    context.SaveChanges();
                }
            }
        }

        public IActionResult EagerLoadingIndex()
        {
            var orders = db.Albums
                    .Include(x => x.Singer)
                    .ToList();
            return View(orders.ToList());
        }

        public IActionResult ExplicitLoadingIndex()
        {
            db.Albums.Load();
            db.Singers.Load();
            return View(db.Albums.ToList());
        }

        public IActionResult LazyLoadingIndex()
        {
            var albums = db.Albums.ToList();
            return View(db.Albums.ToList());
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

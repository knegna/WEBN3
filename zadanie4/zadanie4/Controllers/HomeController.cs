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
    public class HomeController : Controller
    {
        AlbumContext db;
        public HomeController(AlbumContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

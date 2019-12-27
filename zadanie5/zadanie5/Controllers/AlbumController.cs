using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using zadanie5.Models;
using zadanie5.ViewModels;

namespace zadanie5.Controllers
{
    public class AlbumController: Controller
    {
        AlbumContext db;

        public AlbumController(AlbumContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult AddNewAlbum()
        {
            List<Singer> singerModels = db.Singers
                //                .Select(c => new BrandModel { Id = c.Id, Name = c.Name })
                .ToList();
            // добавляем на первое место

            List<Album> _albums = db.Albums.ToList();
            IndexViewModel ivm = new IndexViewModel { Singers = singerModels, Albums = _albums };

            return View(ivm);
        }
        [HttpPost]
        public IActionResult AddNewAlbum(string submit, string cancel, Album album)
        {
            var button = submit ?? cancel;
            if (button == "Cancel")
            {
                return RedirectToAction("AddNewAlbum");
            }

            if (db.Albums.Any(x => x.Name == album.Name))
            {
                return BadRequest();
            }
            db.Albums.Add(album);
            db.SaveChanges();
            return Redirect("~/Home/Index");
        }

        public async Task<IActionResult> Index(int? singer, string name, int page = 1,
            SortState sortOrder = SortState.NameAsc)
        {
            int pageSize = 3;

            //фильтрация
            IQueryable<Album> albums = db.Albums.Include(x => x.Pevets);

            if (singer != null && singer != 0)
            {
                albums = albums.Where(p => p.SingerId == singer);
            }
            if (!String.IsNullOrEmpty(name))
            {
                albums = albums.Where(p => p.Name.Contains(name));
            }

            // сортировка
            switch (sortOrder)
            {
                case SortState.NameDesc:
                    albums = albums.OrderByDescending(s => s.Name);
                    break;
                case SortState.SingerAsc:
                    albums = albums.OrderBy(s => s.Pevets.Name);
                    break;
                case SortState.SingerDesc:
                    albums = albums.OrderByDescending(s => s.Pevets.Name);
                    break;
                default:
                    albums = albums.OrderBy(s => s.Name);
                    break;
            }

            // пагинация
            var count = await albums.CountAsync();
            var items = await albums.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            // формируем модель представления
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModel = new SortViewModel(sortOrder),
                FilterViewModel = new FilterViewModel(db.Singers.ToList(), singer, name),
                Albums = items
            };
            return View(viewModel);
        }
    }
}

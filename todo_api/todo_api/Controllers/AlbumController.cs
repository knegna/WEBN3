using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using todo_api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace todo_api.Controllers
{
    [Route("api/[controller]")]
    public class PerfumesController : Controller
    {
        AlbumStoreContext db;
        public PerfumesController(AlbumStoreContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Album>>> Get()
        {
            return await db.Albums.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Album>> Get(int id)
        {
            Album album = await db.Albums.FirstOrDefaultAsync(x => x.Id == id);
            if (album == null)
                return NotFound();
            return new ObjectResult(album);
        }

        [HttpPost]
        public async Task<ActionResult<Album>> Post([FromForm] Album album)
        {
            if (album == null || db.Albums.Any(x => x.Name == album.Name) || !db.Albums.Any(x => x.Id == album.SingerId))
            {
                return BadRequest();
            }

            db.Albums.Add(album);
            await db.SaveChangesAsync();
            return Ok(album);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Album>> Put(int id, [FromForm] Album album)
        {
            Album albumTemplate = db.Albums.FirstOrDefault(x => x.Id == id);
            if (albumTemplate == null)
            {
                return NotFound();
            }
            albumTemplate.Name = album.Name == null ? albumTemplate.Name : album.Name;
            albumTemplate.Date = album.Date == " " ? albumTemplate.Date : album.Date;
            
            db.Update(albumTemplate);
            await db.SaveChangesAsync();
            return Ok(albumTemplate);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Album>> Delete(int id)
        {
            Album album = db.Albums.FirstOrDefault(x => x.Id == id);
            if (album == null)
            {
                return NotFound();
            }
            db.Albums.Remove(album);
            await db.SaveChangesAsync();
            return Ok(album);
        }
    }
}

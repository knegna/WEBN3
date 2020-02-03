using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using todo_api.Models;

namespace todo_api.Controllers
{
    public class SingerController
    {
        [ApiController]
        [Route("api/[controller]")]
        public class BrandsController : ControllerBase
        {
            AlbumStoreContext db;
            public BrandsController(AlbumStoreContext context)
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

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Singer>>> Get()
            {
                return await db.Singers.ToListAsync();
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Singer>> Get(int id)
            {
                Singer singer = await db.Singers.FirstOrDefaultAsync(x => x.Id == id);
                if (singer == null)
                    return NotFound();
                return new ObjectResult(singer);
            }

            [HttpPost]
            public async Task<ActionResult<Singer>> Post([FromForm] Singer singer)
            {
                if (singer == null || db.Singers.Any(x => x.Name == singer.Name))
                {
                    return BadRequest();
                }

                db.Singers.Add(singer);
                await db.SaveChangesAsync();
                return Ok(singer);
            }

            [HttpPut("{id}")]
            public async Task<ActionResult<Singer>> Put(int id, [FromForm] Singer singer)
            {
                Singer singerTemplate = db.Singers.FirstOrDefault(x => x.Id == id);
                if (singerTemplate == null)
                {
                    return NotFound();
                }
                singerTemplate.Name = singer.Name == null ? singerTemplate.Name : singer.Name;
                singerTemplate.Birthdate = singer.Birthdate == null ? singerTemplate.Birthdate : singer.Birthdate;

                db.Update(singerTemplate);
                await db.SaveChangesAsync();
                return Ok(singerTemplate);
            }

            [HttpDelete("{id}")]
            public async Task<ActionResult<Singer>> Delete(int id)
            {
                Singer singer = db.Singers.FirstOrDefault(x => x.Id == id);
                if (singer == null)
                {
                    return NotFound();
                }
                db.Singers.Remove(singer);
                await db.SaveChangesAsync();
                return Ok(singer);
            }
        }
    }
}


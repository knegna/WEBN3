using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zadanie4.Models;

namespace zadanie4
{
    public class SampleData
    {
        public static void Initialize(AlbumContext context)
        {
            if (!context.Albums.Any())
            {
                context.Albums.AddRange(
                    new Album
                    {
                        Name = "Album 1",
                        ColSongs = 10,
                        Date = "10/10/07"
                    },
                    new Album
                    {
                        Name = "Album 2",
                        ColSongs = 12,
                        Date = "12/12/12"
                    },
                    new Album
                    {
                        Name = "Album 3",
                        ColSongs = 4,
                        Date = "13/10/19"
                    }
                    );
                context.SaveChanges();
            }

            if (!context.Singers.Any())
            {
                context.Singers.AddRange(
                    new Singer
                    {
                        Firstname = "Igor",
                        Lastname = "Ivanov",
                        Birthdate = "1/12/2000"
                    },
                    new Singer
                    {
                        Firstname = "Oleg",
                        Lastname = "Petrov",
                        Birthdate = "12/10/1989"
                    },
                    new Singer
                    {
                        Firstname = "Petr",
                        Lastname = "Smirnov",
                        Birthdate = "20/05/1999"
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}

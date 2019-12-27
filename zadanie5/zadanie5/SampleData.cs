using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using zadanie5.Models;
using Microsoft.EntityFrameworkCore.Internal;

namespace zadanie5
{
    public class SampleData
    {
        public static void Initialize(AlbumContext context)
        {
            Singer EdSheeran = new Singer { Name = "EdSheeran", Birthdate = "10.10.2000"};
            Singer Adelle = new Singer {Name = "Adelle", Birthdate = "15.01.1999"};
            Singer MJaskon = new Singer {Name = "MichaleJackson", Birthdate = "07.02.1989"};
            Singer NBHD = new Singer { Name = "The Neighbourhood", Birthdate = "09.10.1985" };

            if (!context.Singers.Any())
            {
                context.Singers.AddRange(EdSheeran, Adelle, MJaskon, NBHD);
                context.SaveChanges();
            }

            if (!context.Albums.Any())
            {
                context.Albums.AddRange(
                    new Album {
                        Pevets = EdSheeran,
                        Date = "14.02.15",
                        Name = "Love"
                    },
                    new Album {
                        Pevets = Adelle,
                        Name = "heart",
                        Date = "18.09.19"
                    },
                    new Album {
                        Pevets = MJaskon,
                        Name = "Sing",
                        Date = "09.08.17"
                    },
                    new Album {
                        Pevets = EdSheeran,
                        Name = "Dance",
                        Date = "2.12.18"
                    },
                    new Album
                    {
                        Pevets = NBHD,
                        Name = "Grey",
                        Date = "03.02.2018"
                    },
                    new Album
                    {
                        Pevets = NBHD,
                        Name = "Black",
                        Date = "18.08.2015"
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}

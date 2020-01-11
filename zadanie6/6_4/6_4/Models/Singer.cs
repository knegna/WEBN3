using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _6_4
{
    public class Singer
    {
        public int Id { set; get; }
        public string Name { get; set; }
        public string Birthdate { set; get; }

        public virtual List<Album> Albums { get; set; }
    }
}

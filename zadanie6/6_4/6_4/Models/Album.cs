using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _6_4
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }

        public virtual Singer Singer { get; set; }
    }
}

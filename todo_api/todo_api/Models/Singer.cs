using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todo_api.Models
{
    public class Singer
    {
        public int Id { set; get; }
        public string Name { get; set; }
        public string Birthdate { set; get; }

        public ICollection<Album> Albums { get; set; }

        public Singer()
        {
            Albums = new List<Album>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todo_api.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }

        public Singer Singer { get; set; }
        public int SingerId { get; set; }
    }
}

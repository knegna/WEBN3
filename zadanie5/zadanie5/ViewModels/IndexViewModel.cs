using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zadanie5.Models;

namespace zadanie5.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Album> Albums { get; set; }
        public IEnumerable<Singer> Singers { get; set; }

        public PageViewModel PageViewModel { get; set; }
        public FilterViewModel FilterViewModel { get; set; }
        public SortViewModel SortViewModel { get; set; }
    }
}

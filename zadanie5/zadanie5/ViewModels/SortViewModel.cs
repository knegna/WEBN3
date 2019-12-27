using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
public enum SortState
{
    NameAsc,    // по имени по возрастанию
    NameDesc,   // по имени по убыванию
    SingerAsc, // по компании по возрастанию
    SingerDesc // по компании по убыванию
}
namespace zadanie5.ViewModels
{
    public class SortViewModel
    {
        public SortState NameSort { get; private set; } // значение для сортировки по имени
        public SortState SingerSort { get; private set; }   // значение для сортировки по компании
        public SortState Current { get; private set; }     // текущее значение сортировки

        public SortViewModel(SortState sortOrder)
        {
            NameSort = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            SingerSort = sortOrder == SortState.SingerAsc ? SortState.SingerDesc : SortState.SingerAsc;
            Current = sortOrder;
        }
    }
}

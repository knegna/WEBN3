using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using zadanie5.Models;

namespace zadanie5.ViewModels
{
    public class FilterViewModel
    {
        public SelectList Singers { get; private set; }
        public int? SelectedSinger { get; private set; }
        public string SelectedName { get; private set; }
        public FilterViewModel(List<Singer> singers, int? singer, string name)
        {
            // устанавливаем начальный элемент, который позволит выбрать всех
            singers.Insert(0, new Singer { Name = "All", Id = 0, Birthdate = "01.01.01" });
            Singers = new SelectList(singers, "Id", "Name", singer);
            SelectedSinger = singer;
            SelectedName = name;
        }
    }
}

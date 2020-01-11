using System;
using System.Linq;

namespace _6__11
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // создаем два объекта User
                Singer EdSheeran = new Singer { Name = "EdSheeran", Birthdate = "10.10.2000" };
                Singer Adelle = new Singer { Name = "Adelle", Birthdate = "15.01.1999" };
                Singer MJaskon = new Singer { Name = "MichaleJackson", Birthdate = "07.02.1989" };
                Singer NBHD = new Singer { Name = "The Neighbourhood", Birthdate = "09.10.1985" };

                // добавляем их в бд
                db.Singers.Add(EdSheeran);
                db.Singers.Add(Adelle);
                db.Singers.Add(MJaskon);
                db.Singers.Add(NBHD);

                db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены");

                // получаем объекты из бд и выводим на консоль
                var singers = db.Singers.ToList();
                Console.WriteLine("Список объектов:");
                foreach (Singer s in singers)
                {
                    Console.WriteLine($"{s.Id}.{s.Name} - {s.Birthdate}");
                }
            }
            Console.Read();
        }
    }
}

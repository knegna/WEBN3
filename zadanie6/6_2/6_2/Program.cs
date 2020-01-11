using System;
using System.Linq;

namespace _6_2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (helloappdbContext db = new helloappdbContext())
            {
                // получаем объекты из бд и выводим на консоль
                var singers = db.Singers.ToList();
                Console.WriteLine("Список объектов:");
                foreach (Singer s in singers)
                {
                    Console.WriteLine($"{s.Id}.{s.Name} - {s.Birthdate}");
                }
            }
            Console.ReadKey();
        }
    }
}

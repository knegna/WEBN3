using System;

namespace zadanie5.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }

        public Singer Pevets { get; set; }
        public int SingerId { get; set; }

        public DateTime CreationDate = DateTime.Now;

        public TimeSpan LifeTime
        {
            get
            {
                return DateTime.Now.Subtract(CreationDate);
            }
        }
    }
}

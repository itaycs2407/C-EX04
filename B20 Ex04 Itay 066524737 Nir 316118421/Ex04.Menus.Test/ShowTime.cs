using Ex04.Menus.Interfaces;
using System;

namespace Ex04.Menus.Test
{
    public class ShowTime : IMenu
    {
        public void Run()
        {
            printCurrentTime();
        }
        private void printCurrentTime()
        {
          
            
            DateTime time = new DateTime();
            time = DateTime.Now;
            Console.WriteLine(@"Current time is : {0}:{1}", time.Hour, time.Minute);
        }
    }

}

using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class ShowDate : IMenu
    {
        public void Run()
        {
            printCurrentDate();
        }

        private void printCurrentDate()
        {
            DateTime time = new DateTime();
            time = DateTime.Now;
            Console.WriteLine(@"Current date is : {0}/{1}/{2}", time.Day, time.Month, time.Year);
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ex04.Menus.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            showTime();
            showDate();
            showVersion();
            countCapitals();
            Console.ReadLine();
        }

        private static void countCapitals()
        {
            int i, capitalCounter = 0;
            char currentLetter;
            Console.WriteLine("Please write a sentence :");
            string sentenceFromUser = Console.ReadLine();
            for (i = 0; i < sentenceFromUser.Length; i++)
            {
                currentLetter = sentenceFromUser[i];
                if (char.IsUpper(currentLetter))
                {
                    capitalCounter++;
                }
            }
            Console.WriteLine(@"There are {0} capital letters in the sentence you entered.", capitalCounter);
        }

        private static void showVersion()
        {
           Console.WriteLine("Version: 20.2.4.30620");
        }

        private static void showTime()
        {
            DateTime time = new DateTime();
            time = DateTime.Now;
            Console.WriteLine(@"Current time is : {0}:{1}", time.Hour, time.Minute);
        }

        private static void showDate()
        {
            DateTime time = new DateTime();
            time = DateTime.Now;
            Console.WriteLine(@"Current date is : {0}/{1}/{2}", time.Day, time.Month, time.Year);
        }
    }
}

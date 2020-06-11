using Ex04.Menus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Test
{
    public class CountCapital : IMenu
    {
        public void Run()
        {
            countCapitalsLetters();
        }
        private static void countCapitalsLetters()
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
    }
}

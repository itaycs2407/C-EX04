﻿using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class ShowVersion : IMenu
    {
        public void Run()
        {
            printVersion();
        }

        private static void printVersion()
        {
            Console.WriteLine("Version: 20.2.4.30620");
        }
    }
}

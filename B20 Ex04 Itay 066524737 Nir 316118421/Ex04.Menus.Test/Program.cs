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

           // Test t = new Test();
            //t.InterfaceMenu();
            //Console.WriteLine("Press any key to move to delegate menu");
           // t.DelegatesMenu();

            TestRun t = new TestRun();
            t.RunMe();

        }

    }
}

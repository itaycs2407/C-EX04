using Ex04.Menus.Delegates;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Test
{

    public class Test
    {
        private MenuItem m_DelegateMenuItem;
        public MenuItem DelegateMenuItem { get => m_DelegateMenuItem; set => m_DelegateMenuItem = value; }

        public Test()
        {
            m_DelegateMenuItem = new MenuItem("Delegate Based Menu", "Welcome");
        }

        public void DelegatesMenu()
        {
            m_DelegateMenuItem.InsertChildMenu(new MenuItem("V&T","Version and Digits"));
            m_DelegateMenuItem.ChildMenus.FirstOrDefault().InsertChildMenu(new ActionMenuItem("Count Capitals","Count Capitals",printCountCapital));
            m_DelegateMenuItem.ChildMenus.FirstOrDefault().InsertChildMenu(new ActionMenuItem("Show Version", "Show Version", printVersion));
            m_DelegateMenuItem.InsertChildMenu(new MenuItem("Show D&T", "Show Date/ Time"));
            m_DelegateMenuItem.ChildMenus.LastOrDefault().InsertChildMenu(new ActionMenuItem("Show Time", "Show Time", printTime));
            m_DelegateMenuItem.ChildMenus.LastOrDefault().InsertChildMenu(new ActionMenuItem("Show Date", "Show Date", printDate));
            m_DelegateMenuItem.OnMenuStartUp();
        }
        private void printDate()
        {
            Console.WriteLine(DateTime.Now.ToShortDateString());
        }
        private void printTime()
        {
            Console.WriteLine(DateTime.Now.ToLocalTime());
        }
        private void printCountCapital()
        {
            Console.WriteLine("Please writ a sentence:");
            string input = Console.ReadLine();
            int captialLettersCount = 0;
            foreach (char ch in input)
            {
                if (ch < 'Z' && ch >'A')
                {
                    captialLettersCount++;
                }
            }
            Console.WriteLine(@"There were {0} capital letter in your sentence", captialLettersCount);
        }
        private void printVersion()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fileVersionInfo.ProductVersion;
            Console.WriteLine(version);
        }
    }
}

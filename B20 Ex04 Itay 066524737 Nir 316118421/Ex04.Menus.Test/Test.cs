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
        private Ex04.Menus.Delegates.MainMenu m_MenuDelegates;

        //private MenuItem m_InterfaceeMenuItem;
        public MainMenu MainMenu { get => m_MenuDelegates; set => m_MenuDelegates = value; }

        public Test()
        {
            MenuItem delegateMenuItem = new MenuItem("Delegate Based Menu", "Welcome");
            m_MenuDelegates = new MainMenu(delegateMenuItem);
            
            //m_InterfaceeMenuItem = new InterFaceMenuItem();
        }
        public void InterfaceMenu()
        {
            //interface Style
        }
        public void DelegatesMenu()
        {
            //Added first child to menu
            m_MenuDelegates.MenuItem.InsertChildMenu(new MenuItem("V&T","Version and Digits"));

            //Event += implenatation added here to menu
            EventMenuItem showCapitalDelegateRunner = new EventMenuItem("Event+= Delegate(C_Capital)");
            showCapitalDelegateRunner.MenuStartUp += printCountCapital;
            EventMenuItem showVersionDelegateRunner = new EventMenuItem("Event+= Delegate(Version)");
            showVersionDelegateRunner.MenuStartUp += printVersion;
            m_MenuDelegates.MenuItem.ChildMenus.FirstOrDefault().InsertChildMenu(showCapitalDelegateRunner);
            m_MenuDelegates.MenuItem.ChildMenus.FirstOrDefault().InsertChildMenu(showVersionDelegateRunner);

            //Added 2nd child to main menu
            m_MenuDelegates.MenuItem.InsertChildMenu(new MenuItem("Show D&T", "Show Date/ Time"));

            //Event += implenatation added here to menu
            EventMenuItem showTimeDelegateRunner = new EventMenuItem("Event+= Delegate(Time)");
            showTimeDelegateRunner.MenuStartUp += printTime;
            EventMenuItem showDateDelegateRunner = new EventMenuItem("Event+= Delegate(Date)");
            showDateDelegateRunner.MenuStartUp += printDate;
            m_MenuDelegates.MenuItem.ChildMenus.LastOrDefault().InsertChildMenu(showTimeDelegateRunner);
            m_MenuDelegates.MenuItem.ChildMenus.LastOrDefault().InsertChildMenu(showDateDelegateRunner);

            m_MenuDelegates.Show();
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

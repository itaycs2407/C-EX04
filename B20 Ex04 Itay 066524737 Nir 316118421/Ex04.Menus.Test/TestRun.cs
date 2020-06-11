using Ex04.Menus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Test
{
    class TestRun
    {
        private MenuItem m_MainMenuInterface;
       
        public TestRun()
        {
            m_MainMenuInterface = new MenuItem("Welcome", "RootMenu");
            m_MainMenuInterface.Items.Add(new MenuItem("V & D", "Version and Digits"));
            m_MainMenuInterface.Items[0].PrevMenu = m_MainMenuInterface; 
            m_MainMenuInterface.Items[0].Items.Add(new MenuItem("vs","Version"));
            //var a = new ShoDate90;
            m_MainMenuInterface.Items[0].Items[0].MethodToInvoke = new ShowDate();
            m_MainMenuInterface.Items[0].Items[0].MethodToInvoke = new ShowVersion();
            m_MainMenuInterface.Items[0].Items[0].PrevMenu = m_MainMenuInterface.Items[0];
            m_MainMenuInterface.Items[0].Items.Add(new MenuItem("cc", "Count capital letters"));
            m_MainMenuInterface.Items[0].Items[1].MethodToInvoke = new CountCapital();
            m_MainMenuInterface.Items[0].Items[1].PrevMenu = m_MainMenuInterface.Items[0];

            m_MainMenuInterface.Items.Add(new MenuItem("Date & Time", "Show date or time"));
            m_MainMenuInterface.Items[1].PrevMenu = m_MainMenuInterface;
            m_MainMenuInterface.Items[1].Items.Add(new MenuItem("date", "Show date"));
            m_MainMenuInterface.Items[1].Items[0].MethodToInvoke = new ShowDate();
            m_MainMenuInterface.Items[1].Items[0].PrevMenu = m_MainMenuInterface.Items[1];
            m_MainMenuInterface.Items[1].Items.Add(new MenuItem("time", "Show time"));
            m_MainMenuInterface.Items[1].Items[1].MethodToInvoke = new ShowTime();
            m_MainMenuInterface.Items[1].Items[1].PrevMenu = m_MainMenuInterface.Items[1];


        }   
        public void RunMe()
        {
            m_MainMenuInterface.Show();
        }
    }
}

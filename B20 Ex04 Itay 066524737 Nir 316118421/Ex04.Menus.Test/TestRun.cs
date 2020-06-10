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
        private MenuItem m_MainMenu;
        public TestRun()
        {
            m_MainMenu = new MenuItem("Welcome", "RootMenu");
            m_MainMenu.Items.Add(new MenuItem("V & D", "Version and Digits"));
            m_MainMenu.Items[0].Items
        }
    }
}

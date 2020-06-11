using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu
    {
        MenuItem m_MenuItem;

        public MenuItem MenuItem { get => m_MenuItem; set => m_MenuItem = value; }
        public MainMenu()
        {
           
        }
        private void Show()
        {
            m_MenuItem.Show();
        }
    }
}

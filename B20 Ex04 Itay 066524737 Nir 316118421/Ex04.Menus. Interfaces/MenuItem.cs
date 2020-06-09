using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    class MenuItem :IMenu
    {
        private string m_Title;
        private int m_MenuLevel;
        private List<MenuItem> m_BelowMenu; 

        public MenuItem(string i_MenuItem, int i_NumberOfSubMenus , int i_Level)
        {
            Title = i_MenuItem;
            m_BelowMenu = new List<MenuItem>(i_NumberOfSubMenus);
            m_MenuLevel = i_Level;
        }

        public string Title { get => m_Title; set => m_Title = value; }
        public int MenuLevel { get => m_MenuLevel; set => m_MenuLevel = value; }
        internal List<MenuItem> BelowMenu { get => m_BelowMenu; set => m_BelowMenu = value; }

        public void Exit()
        {
            throw new NotImplementedException();
        }

        public void InvokeMenuItem()
        {
            throw new NotImplementedException();
        }
    }
}

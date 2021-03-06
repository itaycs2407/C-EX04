﻿namespace Ex04.Menus.Interfaces
{
    public class MainMenu
    {
        private MenuItem m_MenuItem;

        public MenuItem MenuItem { get => m_MenuItem; set => m_MenuItem = value; }

        public MainMenu(MenuItem i_MenuItem)
        {
            m_MenuItem = i_MenuItem; 
        }

        public void Show()
        {
            m_MenuItem.Show();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    class Root : IMenu
    {
        private List<MenuItem> m_Items;
        private int m_numberOfItems;

        internal List<MenuItem> Items { get => m_Items; set => m_Items = value; }
        public int NumberOfItems { get => m_numberOfItems; set => m_numberOfItems = value; }

        public Root()
        {
            Console.WriteLine("Please enter number of item for the menu :");
            string numberOfItemsSTR = Console.ReadLine();
            int m_numberOfItems;
            while (int.TryParse(numberOfItemsSTR, out m_numberOfItems) && m_numberOfItems < 1)
            {
                Console.WriteLine("Wrong input. Please enter number of item for the menu :");
                numberOfItemsSTR = Console.ReadLine();
            }

            Items = new List<MenuItem>(m_numberOfItems);

            for (int i = 0; i < m_numberOfItems; i++)
            {
                Items.Add(getInputForMenuLevel());
            
            }
        }

        private MenuItem getInputForMenuLevel()
        {
            Console.WriteLine("Enter menu title");
            string menuTitle = Console.ReadLine();
            Console.WriteLine("Enter number of sub menus, 0 for invoke");
            string numberOfSubMenusSTR = Console.ReadLine();
            int numberOfSubMenus;
            while (int.TryParse(numberOfSubMenusSTR, out numberOfSubMenus) && numberOfSubMenus < 0)
            {
                Console.WriteLine("Wrong input. Enter number of sub menus, 0 for invoke");
                numberOfSubMenusSTR = Console.ReadLine();
            }
            
            return new MenuItem(menuTitle, numberOfSubMenus, 1);
    }

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
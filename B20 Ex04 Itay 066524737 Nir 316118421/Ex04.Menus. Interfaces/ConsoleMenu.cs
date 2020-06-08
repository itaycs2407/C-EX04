using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    class ConsoleMenu
    {

        Root m_rootMenuLevel;

        public ConsoleMenu()
        {
            m_rootMenuLevel = new Root();
            reqParseMenuItem(m_rootMenuLevel);
        }

        
        private void reqParseMenuItem(Root i_NodeMenuItem)
        {
            if (i_NodeMenuItem.NumberOfItems == 0)
            {
                // set function to invoke
            }
            else
            {
                for (int i = 0; i < i_NodeMenuItem.NumberOfItems; i++)
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
                    i_NodeMenuItem.Items[i].BelowMenu = new List<MenuItem>(numberOfSubMenus);
                    i_NodeMenuItem.Items[i].MenuLevel = i_NodeMenuItem.Items[i].MenuLevel + 1;
                    i_NodeMenuItem.Items[i].Title = menuTitle;
                    reqParseMenuItem((Root)i_NodeMenuItem.Items[i]);
                    
                }
            }
        } 
        




        private string m_Title;
        private int m_ItemNumber, m_MenuLevel;
        private List<IMenu> m_BelowMenu = new List<IMenu>();
        private static int currentLevel = 0;

        public static int CurrentLevel { get => currentLevel; set => currentLevel = value; }

        /** NOT NECCESSERY 
        private void getUserTopMenu()
        {
            Console.WriteLine("Please enter number of item for the menu :");
            string numberOfItemsSTR = Console.ReadLine();
            int numberOfItems;
            while (int.TryParse(numberOfItemsSTR, out numberOfItems) && numberOfItems < 1)
            {
                Console.WriteLine("Wrong input. Please enter number of item for the menu :");
                numberOfItemsSTR = Console.ReadLine();
            }
            
            for (int i = 0; i < numberOfItems; i++)
            {

            }
            Console.WriteLine("Enter menu title");
            string menuTiyle = Console.ReadLine();
            Console.WriteLine("Enter number of sub menus, 0 for invoke");
            string numberOfSubMenusSTR = Console.ReadLine();
            int numberOfSubMenus;
            while (int.TryParse(numberOfSubMenusSTR,out numberOfSubMenus) && numberOfSubMenus < 0)
            {
                Console.WriteLine("Wrong input. Enter number of sub menus, 0 for invoke");
                numberOfSubMenusSTR = Console.ReadLine();
            }
        }*/

    }
}

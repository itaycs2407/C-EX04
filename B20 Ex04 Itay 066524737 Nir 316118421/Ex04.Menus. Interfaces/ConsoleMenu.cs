using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    class ConsoleMenu
    {

        MenuItem m_rootMenuLevel;
        private string m_Title;
        private int m_ItemNumber, m_MenuLevel;
        private static int currentLevel = 0;
        private string[] methodNames = new string[4]{"showDate","showHour","countCapital","showVersion"};

        public ConsoleMenu()
        {
            Console.WriteLine("Enter menu title");
            m_Title = Console.ReadLine();
            Console.WriteLine("Enter number of sub menus, 0 for invoke");
            string numberOfSubMenuSTR = Console.ReadLine();
            int numberOfSubMenus;

            while (int.TryParse(numberOfSubMenuSTR, out numberOfSubMenus) && numberOfSubMenus < 0)
            {
                Console.WriteLine("Wrong input. Enter number of sub menus, 0 for invoke");
                numberOfSubMenuSTR = Console.ReadLine();
            }

            m_rootMenuLevel = new MenuItem(m_Title, numberOfSubMenus, currentLevel);

            reqBuildMenu(m_rootMenuLevel);
        }

        
        private void reqBuildMenu(MenuItem i_NodeMenuItem)
        {
            if (i_NodeMenuItem.BelowMenu.Count == 0)
            {
                Console.WriteLine(@"please decide wich method to invoke :");
                string userMethodSelect = printMethodPoolAndGetSelect();
               
                // set function to invoke
            }
            else
            {
                for (int i = 0; i < i_NodeMenuItem.BelowMenu.Count; i++)
                {
                    Console.WriteLine("Enter menu title");
                    string menuTitle = Console.ReadLine();
                    Console.WriteLine("Enter number of sub menus, 0 for invoke");
                    string numberOfSubMenuSTR = Console.ReadLine();
                    int numberOfSubMenus;
                    while (int.TryParse(numberOfSubMenuSTR, out numberOfSubMenus) && numberOfSubMenus < 0)
                    {
                        Console.WriteLine("Wrong input. Enter number of sub menus, 0 for invoke");
                        numberOfSubMenuSTR = Console.ReadLine();
                    }

                    i_NodeMenuItem.BelowMenu[i].BelowMenu = new List<MenuItem>(numberOfSubMenus);
                    i_NodeMenuItem.BelowMenu[i].MenuLevel = i_NodeMenuItem.MenuLevel + 1;
                    i_NodeMenuItem.BelowMenu[i].Title = menuTitle;

                    reqBuildMenu(i_NodeMenuItem.BelowMenu[i]);
                    
                }
            }
        }

        private void showMenu(MenuItem m_rootMenuLevel, MenuItem m_ParentMenu)
        {
            Console.WriteLine(m_rootMenuLevel.Title);
            Console.WriteLine("------------------------");
            string goBack = m_rootMenuLevel.MenuLevel == 0 ? "Exit" : "Back";
            Console.WriteLine(@"0 . {0}", goBack);
            for (int i = 0; i < m_rootMenuLevel.BelowMenu.Count; i++)
            {
                Console.WriteLine(@"{0}. {1}",i+1, m_rootMenuLevel.BelowMenu[i].Title);
            }
            Console.Write("Please enter your selection :");
            string userInputSTR = Console.ReadLine();
            int userInput;
            while (int.TryParse(userInputSTR, out userInput) && userInput < 0 || userInput > m_rootMenuLevel.BelowMenu.Count)
            {
                Console.WriteLine("Wrong input. Please enter your selection :");
                userInputSTR = Console.ReadLine();
            }
            if (userInput == 0)
            {
                // go the parent menu
                //clear screen
                showMenu()
            }
            else if (m_rootMenuLevel.BelowMenu[userInput - 1].BelowMenu.Count == 0)
            {
                // do invokation
            }
            else
            {
                //clear the screen
                showMenu(m_rootMenuLevel.BelowMenu[userInput - 1], m_rootMenuLevel);
            }
        }

        private string printMethodPoolAndGetSelect()
        {
            for (int i = 0; i < methodNames.Length; i++)
            {
                Console.WriteLine(@"{0}. {1}", i+1,methodNames[i]);
            }
            Console.Write("Please select your choice :");
            string userInputSTR = Console.ReadLine();
            int userInput;
            while (int.TryParse(userInputSTR, out userInput) && userInput > methodNames.Length || userInput < 1)
            {
                Console.Write("Please select your choice :");
                userInputSTR = Console.ReadLine();
            }

            return methodNames[userInput];
        }

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

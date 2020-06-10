using System;
using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    public class MenuItem
    {
        private string m_Header;
        private string m_Title;
        private IMenu methodToInvoke = null;
        private List<MenuItem> items = new List<MenuItem>();
        private MenuItem prevMenu;

        public string Header { get => m_Header; set => m_Header = value; }
        public string Title { get => m_Title; set => m_Title = value; }
        public IMenu MethodToInvoke { get => methodToInvoke; set => methodToInvoke = value; }
        public List<MenuItem> Items { get => items; set => items = value; }
        public MenuItem PrevMenu { get => prevMenu; set => prevMenu = value; }

        public MenuItem(string i_Header, string i_Title)
        {
            Header = i_Header;
            Title = i_Title;
        }

        private void printMenu()
        {
            Console.Clear();
            string back = this.PrevMenu == null ? "Exit" : "Back";
            Console.WriteLine(Header);
            Console.WriteLine("-----------------");
            Console.WriteLine(@"0. {0}", back);
            int index = 1;
            Items.ForEach(item =>
            {
                Console.WriteLine(@"{0}. {1}",index++,item.Title);
            });
            Console.Write("Enter your choise : ");
            string userSelectionSTR = Console.ReadLine();
            int userSelection;     
            while (int.TryParse(userSelectionSTR, out userSelection) && userSelection < 0 || userSelection >= index)
            {
                Console.Write("Wrong Choise. Enter your choise : ");
                userSelectionSTR = Console.ReadLine();
            }
            
            if (userSelection == 0)
            {
                this.PrevMenu.printMenu();
            }
            else
            {
                if (this.Items.Count == 0 && this.methodToInvoke != null)
                {
                    this.methodToInvoke.Run();
                }
                else
                {
                    this.Items[userSelection - 1].printMenu();
                }
            }
            
        }
    }
}

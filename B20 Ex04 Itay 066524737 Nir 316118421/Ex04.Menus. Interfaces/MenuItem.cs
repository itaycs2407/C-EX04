using System;
using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    public class MenuItem
    {
        private string m_Title;
        private IMenu methodToInvoke = null;
        private List<MenuItem> items = new List<MenuItem>();
        private MenuItem prevMenu;

        public string Title { get => m_Title; set => m_Title = value; }

        public IMenu MethodToInvoke { get => methodToInvoke; set => methodToInvoke = value; }

        public List<MenuItem> Items { get => items; set => items = value; }

        public MenuItem PrevMenu { get => prevMenu; set => prevMenu = value; }

        public MenuItem(string i_Title)
        {
            Title = i_Title;
        }

        public void Show()
        {
            if (MethodToInvoke != null)
            {
                methodToInvoke.Run();
                Console.ReadLine();
                goBack();
            }
            else
            {
                Console.Clear();
                string returnToPrevMenuString = PrevMenu == null ? "Exit" : "Back";
                Console.WriteLine(Title);
                Console.WriteLine("-----------------");
                Console.WriteLine(@"0. {0}", returnToPrevMenuString);
                int index = 1;
                Items.ForEach(item =>
                {
                    Console.WriteLine(@"{0}. {1}", index++, item.Title);
                });
                Console.Write("Enter your choise : ");
                string userSelectionSTR = Console.ReadLine();
                int userSelection;
                while (!int.TryParse(userSelectionSTR, out userSelection) || userSelection < 0 || userSelection > Items.Count)
                {
                    Console.WriteLine("Invalid input, Please type a number of your choice between 1 and {0} (Or 0 to exit this menu): ", Items.Count);
                    userSelectionSTR = Console.ReadLine();
                }

                if (userSelection == 0)
                {
                    goBack();
                }
                else
                {
                    if (Items.Count == 0 && methodToInvoke != null)
                    {
                        methodToInvoke.Run();
                    }
                    else
                    {
                        Items[userSelection - 1].Show();
                    }
                }
            }
        }

        private void goBack()
        {
            if (prevMenu != null)
            {
                PrevMenu.Show();
            }
        }
    }
}

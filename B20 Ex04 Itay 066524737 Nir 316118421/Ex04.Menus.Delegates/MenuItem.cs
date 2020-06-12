using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex04.Menus.Delegates
{
     public class MenuItem
    {
        #region Fields
        private const int m_ExitIndex = 0;
        private string m_Title;
        private List<MenuItem> m_ChildMenus;
        private MenuItem m_PrevMenu;
        #endregion Fields
        
        #region Getters+Setters
        public string Title { get => m_Title; set => m_Title = value; }

        public List<MenuItem> ChildMenus { get => m_ChildMenus; }

        protected MenuItem PrevMenu { get => m_PrevMenu; set => m_PrevMenu = value; }

        #endregion Getters+Setters

        #region C'tors
        public MenuItem(string i_Title)
        {
            m_Title = i_Title;
        }
        #endregion C'tors

        #region Public Methods
        public virtual void OnMenuStartUp()
        {
            Console.Clear();
            int index = 1;
            Console.WriteLine(Title);
            string backString = m_PrevMenu == null ? "Exit" : "Back";
            Console.WriteLine("{0}. {1}", m_ExitIndex, backString);
            m_ChildMenus.ForEach(menu =>
            {
                Console.WriteLine(@"{0}. {1}", index, menu.Title);
                index++;
            });
            int userChoiceInput = getUsersChoice();
            invokeUsersAction(userChoiceInput);
        }

        public void InsertChildMenu(MenuItem i_ChildMenuToInsert)
        {
            i_ChildMenuToInsert.PrevMenu = this;
            if (m_ChildMenus == null)
            {
                m_ChildMenus = new List<MenuItem>
                {
                    i_ChildMenuToInsert
                };
            }
            else
            {
                m_ChildMenus.Add(i_ChildMenuToInsert);
            }
        }
        #endregion Public Methods
       
        #region Private Methods
        private void invokeUsersAction(int i_UserChoiceInput)
        {
            if (i_UserChoiceInput <= m_ChildMenus.Count && i_UserChoiceInput > 0) 
            {
                m_ChildMenus[i_UserChoiceInput - 1].OnMenuStartUp();
            }
            else if(m_PrevMenu != null)
            {
                m_PrevMenu.OnMenuStartUp();
            }
        }

        private int getUsersChoice()
        {
            Console.WriteLine("Please choose an option between 0 and {0} : ", m_ChildMenus.Count);
            
            string userInput = Console.ReadLine();
            int userIntUnput;
            bool isValidInput = int.TryParse(userInput, out userIntUnput);
            while (!isValidInput || userIntUnput < 0 || userIntUnput > m_ChildMenus.Count)
            {
                Console.WriteLine("Invalid input, Please type a number of your choice between 0 and {0} (Or {1} to exit this menu): ", m_ChildMenus.Count, m_ExitIndex);
                userInput = Console.ReadLine();
                isValidInput = int.TryParse(userInput, out userIntUnput);
            }

            return userIntUnput;
        }
        #endregion Private Methods
    }
}

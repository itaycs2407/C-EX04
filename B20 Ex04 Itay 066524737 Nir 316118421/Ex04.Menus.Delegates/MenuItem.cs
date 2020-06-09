using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Delegates
{
    public delegate void ActionClickedDelegate();
    class MenuItem
    {
        #region Fields
        private string m_Title;
        private List<MenuItem> m_ChildMenus;
        private MenuItem m_PrevMenu;
        private string m_MessageToShow;
        private const int m_ExitIndex = 0;
        #endregion Fields
        
        #region Getters+Setters
        public string Title { get => m_Title; set => m_Title = value; }
        internal List<MenuItem> ChildMenus { get => m_ChildMenus; set => m_ChildMenus = value; }
        internal MenuItem PrevMenu { get => m_PrevMenu; set => m_PrevMenu = value; }
        public string MessageToShow { get => m_MessageToShow; set => m_MessageToShow = value; }
        #endregion Getters+Setters

        #region C'tors
        public MenuItem(string i_Title, string i_MessageToShow)
        {
            m_Title = i_Title;
            m_MessageToShow = i_MessageToShow;
        }
        #endregion C'tors

        #region Public Methods
        public virtual void OnMenuStartUp()
        {
            int index = 1;
            m_ChildMenus.ForEach(menu =>
            {
                Console.WriteLine(@"{0}. {1}",index, menu.Title);
                index++;
            });
            
            Console.WriteLine(m_MessageToShow);
            int userChoiceInput = getUsersChoice();
            invokeUsersAction(userChoiceInput - 1);

        }
        public void InsertChildMenu(MenuItem i_ChildMenuToInsert)
        {
            i_ChildMenuToInsert.PrevMenu = this;
            if (m_ChildMenus == null)
            {
                m_ChildMenus = new List<MenuItem>();
                m_ChildMenus.Add(i_ChildMenuToInsert);
            }
            m_ChildMenus.Add(i_ChildMenuToInsert);
        }
        public void RemoveChildMenu(MenuItem i_ChildMenuToRemove)
        {
            if(m_ChildMenus != null)
            {
                if (m_ChildMenus.FirstOrDefault(menu => menu == i_ChildMenuToRemove) != null)
                {
                    i_ChildMenuToRemove.PrevMenu = null;
                    m_ChildMenus.Remove(i_ChildMenuToRemove);
                }
            }
        }
        #endregion Public Methods
       
        #region Private Methods
        private void invokeUsersAction(int i_UserChoiceInput)
        {
            if (i_UserChoiceInput < m_ChildMenus.Count && i_UserChoiceInput > 0) // Entered child
            {
                m_ChildMenus[i_UserChoiceInput].OnMenuStartUp();
            }
            else //Entered 0
            {
                m_PrevMenu.OnMenuStartUp();
            }

        }
        private int getUsersChoice()
        {
            Console.WriteLine("Please choose an option between 1 and {0} : ", m_ChildMenus.Count);
            Console.WriteLine("Or press {0} to exit this menu", m_ExitIndex);
            string userInput = Console.ReadLine();
            int userIntUnput;
            bool isValidInput = int.TryParse(userInput, out userIntUnput);
            while (!isValidInput || userIntUnput < 0 || userIntUnput > m_ChildMenus.Count)
            {
                Console.WriteLine("Invalid input, Please type a number of your choice between 1 and {0} (Or {1} to exit this menu): "
                    , m_ChildMenus.Count, m_ExitIndex);
                userInput = Console.ReadLine();
                isValidInput = int.TryParse(userInput, out userIntUnput);
            }
            return userIntUnput;
        }
        #endregion Private Methods
    }
}

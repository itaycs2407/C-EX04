using System;

namespace Ex04.Menus.Delegates
{
    public class ActionMenuItem : MenuItem
    {
        private ActionClickedDelegate m_ActionOnClick;

        public ActionMenuItem(string i_Title, string i_MessageToShow, ActionClickedDelegate i_ActionOnClick) : base(i_Title, i_MessageToShow)
        {
            m_ActionOnClick = i_ActionOnClick;
        }

        public override void OnMenuStartUp()
        {
            if (m_ActionOnClick != null)
            {
                m_ActionOnClick.Invoke();
            }
            else
            {
                Console.WriteLine("No function was added to this option :( ");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            PrevMenu.OnMenuStartUp();
        }

        public ActionClickedDelegate ActionOnClick { get => m_ActionOnClick; set => m_ActionOnClick = value; }
    }
}

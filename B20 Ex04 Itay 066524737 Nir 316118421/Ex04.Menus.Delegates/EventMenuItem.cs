using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Delegates
{
    public class EventMenuItem : MenuItem
    {
        public event Action MenuStartUp;

        public EventMenuItem(string i_Title) : base(i_Title, "")
        {
        }

        public override void OnMenuStartUp()
        {
            if (MenuStartUp != null)
            {
                MenuStartUp.Invoke();
            }
            else
            {
                Console.WriteLine("No function was added to this option :( ");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            PrevMenu.OnMenuStartUp();

        }
    }
}

namespace Ex04.Menus.Test
{
    public class TestRun
    {
        #region Menu messages
        private const string k_DateAndTimeMenu = "Date and time menu";
        private const string k_CountCapitalsAndVersionMenu = "Count capital letters and version menu";
        private const string k_DateMenuAction = "Show date";
        private const string k_TimeMenuAction = "Show time";
        private const string k_CountCapitalsMenuAction = "Count capital letters in a sentence";
        private const string k_VersionMenuAction = "Show version";
        #endregion Menu messages
        private Interfaces.MainMenu m_MainMenuInterface;
        private Delegates.MainMenu m_MainMenuDelegates;
        private Interfaces.IMenu m_ShowDate;
        private Interfaces.IMenu m_ShowTime;
        private Interfaces.IMenu m_CountCapitals;
        private Interfaces.IMenu m_ShowVersion;

        public TestRun()
        {
            m_ShowDate = new ShowDate();
            m_ShowTime = new ShowTime();
            m_ShowVersion = new ShowVersion();
            m_CountCapitals = new CountCapital();
        }   

        private void runInterface()
        {
            m_MainMenuInterface = new Interfaces.MainMenu(new Interfaces.MenuItem("Interface Menu"));

            // Added first child to menu
            m_MainMenuInterface.MenuItem.Items.Add(new Interfaces.MenuItem(k_CountCapitalsAndVersionMenu));
            m_MainMenuInterface.MenuItem.Items[0].PrevMenu = m_MainMenuInterface.MenuItem;
            m_MainMenuInterface.MenuItem.Items[0].Items.Add(new Interfaces.MenuItem(k_CountCapitalsMenuAction));
            m_MainMenuInterface.MenuItem.Items[0].Items[0].MethodToInvoke = m_CountCapitals;
            m_MainMenuInterface.MenuItem.Items[0].Items[0].PrevMenu = m_MainMenuInterface.MenuItem.Items[0];
            m_MainMenuInterface.MenuItem.Items[0].Items.Add(new Interfaces.MenuItem(k_VersionMenuAction));
            m_MainMenuInterface.MenuItem.Items[0].Items[1].MethodToInvoke = m_ShowVersion;
            m_MainMenuInterface.MenuItem.Items[0].Items[1].PrevMenu = m_MainMenuInterface.MenuItem.Items[0];
            
            // Added 2nd child to main menu
            m_MainMenuInterface.MenuItem.Items.Add(new Interfaces.MenuItem(k_DateAndTimeMenu));
            m_MainMenuInterface.MenuItem.Items[1].PrevMenu = m_MainMenuInterface.MenuItem;
            m_MainMenuInterface.MenuItem.Items[1].Items.Add(new Interfaces.MenuItem(k_TimeMenuAction));
            m_MainMenuInterface.MenuItem.Items[1].Items[0].MethodToInvoke = m_ShowTime;
            m_MainMenuInterface.MenuItem.Items[1].Items[0].PrevMenu = m_MainMenuInterface.MenuItem.Items[1];
            m_MainMenuInterface.MenuItem.Items[1].Items.Add(new Interfaces.MenuItem(k_DateMenuAction));
            m_MainMenuInterface.MenuItem.Items[1].Items[1].MethodToInvoke = m_ShowDate;
            m_MainMenuInterface.MenuItem.Items[1].Items[1].PrevMenu = m_MainMenuInterface.MenuItem.Items[1];
            m_MainMenuInterface.Show();
        }

        private void runDelegate()
        {
            m_MainMenuDelegates = new Delegates.MainMenu(new Delegates.MenuItem("Delegates Menu"));
            
            // Added first child to menu
            m_MainMenuDelegates.MenuItem.InsertChildMenu(new Delegates.MenuItem(k_CountCapitalsAndVersionMenu));
            Delegates.EventMenuItem showCapitalDelegateRunner = new Delegates.EventMenuItem(k_CountCapitalsMenuAction);
            showCapitalDelegateRunner.MenuStartUp += m_CountCapitals.Run;
            Delegates.EventMenuItem showVersionDelegateRunner = new Delegates.EventMenuItem(k_VersionMenuAction);
            showVersionDelegateRunner.MenuStartUp += m_ShowVersion.Run;
            m_MainMenuDelegates.MenuItem.ChildMenus[0].InsertChildMenu(showCapitalDelegateRunner);
            m_MainMenuDelegates.MenuItem.ChildMenus[0].InsertChildMenu(showVersionDelegateRunner);

            // Added 2nd child to main menu
            m_MainMenuDelegates.MenuItem.InsertChildMenu(new Delegates.MenuItem(k_DateAndTimeMenu));
            Delegates.EventMenuItem showDateDelegateRunner = new Delegates.EventMenuItem(k_DateMenuAction);
            showDateDelegateRunner.MenuStartUp += m_ShowDate.Run;
            Delegates.EventMenuItem showTimeDelegateRunner = new Delegates.EventMenuItem(k_TimeMenuAction);
            showTimeDelegateRunner.MenuStartUp += m_ShowTime.Run;
            m_MainMenuDelegates.MenuItem.ChildMenus[1].InsertChildMenu(showTimeDelegateRunner);
            m_MainMenuDelegates.MenuItem.ChildMenus[1].InsertChildMenu(showDateDelegateRunner);
            m_MainMenuDelegates.Show();
        }

        public void RunMe()
        {
            runInterface();
            runDelegate();
        }
    }
}

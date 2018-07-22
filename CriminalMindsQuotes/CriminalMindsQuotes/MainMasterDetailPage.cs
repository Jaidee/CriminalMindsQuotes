using Xamarin.Forms;

using CriminalMindsQuotes.Pages;

namespace CriminalMindsQuotes
{
    public class MainMasterDetailPage : MasterDetailPage
    {
        public MainMasterDetailPage()
        {
            var master = new MainMasterPage();

            if (Device.RuntimePlatform == Device.iOS)
                master.Icon = (FileImageSource)ImageSource.FromFile("nav-menu-icon.png");

            this.Master = master;
            this.MasterBehavior = MasterBehavior.Popover;

            master.PageSelected += MasterPageSelected;

            PrensentDetailPage(PageType.TodayQuotes);
        }

        void MasterPageSelected(object sender, PageType e)
        {
            PrensentDetailPage(e);
        }

        void PrensentDetailPage(PageType pageType)
        {
            Page viewPage = null;

            switch (pageType)
            {
                case PageType.TodayQuotes:
                    viewPage = new TodayQuotesPage();
                    break;
                case PageType.Episodes:
                    viewPage = new EpisodePage();
                    break;
                case PageType.TheBauTeam:
                    viewPage = new MainActorPage();
                    break;
                case PageType.RecurActors:
                    viewPage = new RecurActorsPage();
                    break;
                case PageType.Settings:
                    viewPage = new SettingsNavPage();
                    break;
                default:
                    viewPage = new TodayQuotesPage();
                    break;
            }

            Detail = new NavigationPage(viewPage);

            try
            {
                IsPresented = false;
            }
            catch { }
        }
    }
}


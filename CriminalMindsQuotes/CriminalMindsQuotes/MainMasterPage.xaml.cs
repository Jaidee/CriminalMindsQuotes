using System;
using System.Threading.Tasks;

using Xamarin.Forms;
using CriminalMindsQuotes.Pages;

namespace CriminalMindsQuotes
{
    public partial class MainMasterPage : ContentPage
    {
        public event EventHandler<PageType> PageSelected;

        public MainMasterPage()
        {
            InitializeComponent();
        }

        void OnTodayQuotesTapped (object s, EventArgs e)
        {
            PageSelected?.Invoke(this, PageType.TodayQuotes);
        }

        void OnEpisodesTapped (Object s, EventArgs e)
        {
            PageSelected?.Invoke(this, PageType.Episodes);
        }

        void OnTheTeamTapped (object s, EventArgs e)
        {
            PageSelected?.Invoke(this, PageType.TheBauTeam);
        }

        void OnRecurringActorsTapped (object s, EventArgs e)
        {
            PageSelected?.Invoke(this, PageType.RecurActors);
        }

        void OnSettingTapped (object s, EventArgs e)
        {
            PageSelected?.Invoke(this, PageType.Settings);    
        }

        void OnAboutTapped(object s, EventArgs e)
        {
            PageSelected?.Invoke(this, PageType.About);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using CriminalMindsQuotes.Data;

namespace CriminalMindsQuotes.Pages
{
    public partial class TodayQuotesPage : ContentPage
    {
        IList<TodayQuote> todayQuotes = new ObservableCollection<TodayQuote>();
        TodayQuotesData todayQuotesData = new TodayQuotesData();

        public TodayQuotesPage()
        {
            InitializeComponent();

            BuildQuotes();
        }

        public void OnRefrest(object sender, EventArgs e)
        {
            BuildQuotes();
        }

        private async void BuildQuotes()
        {
            this.IsBusy = true;
            this.IsEnabled = false;
            try
            {
                var todayQC = await todayQuotesData.LoadAsync();
                var todayQ = todayQC.Cast<TodayQuote>().ToList();
                var counts = todayQ.Count();

                this.Quote1Text.Text = todayQ[0].Quote;
                this.Quote1Author.Text = todayQ[0].Author;
                this.Quote1Episode.Text = 
                    string.Format("Season {0} Episode {1}", todayQ[0].QuoteSeason, todayQ[0].QuoteEpisode);
                this.Quote1QuoteBy.Text = string.Format("Quoted by: {0}", todayQ[0].QuotedBy);

                if (counts >= 2)
                {
                    this.Quote2Text.Text = todayQ[1].Quote;
                    this.Quote2Author.Text = todayQ[1].Author;
                    this.Quote2Episode.Text =
                        string.Format("Season {0} Episode {1}", todayQ[1].QuoteSeason, todayQ[1].QuoteEpisode);
                    this.Quote2QuoteBy.Text = string.Format("Quoted by: {0}", todayQ[1].QuotedBy);
                }
                else
                {
                    this.Quote2Text.Text = string.Empty;
                    this.Quote2Author.Text = string.Empty;
                    this.Quote2Episode.Text = string.Empty;
                    this.Quote2QuoteBy.Text = string.Empty;
                }
            }
            finally
            {
                this.IsBusy = false;
                this.IsEnabled = true;
            }
        }
    }
}

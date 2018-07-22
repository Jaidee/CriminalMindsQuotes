using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using CriminalMindsQuotes.Data;

namespace CriminalMindsQuotes.Pages
{
    public partial class ActorQuotePage : ContentPage
    {
        IList<ActorQuoteList> actorQuoteList = new ObservableCollection<ActorQuoteList>();
        QuotesData quotesData = new QuotesData();
        EpisodeData episodeData = new EpisodeData();

        public ActorQuotePage(MainActor actor)
        {
            InitializeComponent();

            LoadData(actor);
        }

        public async void LoadData(MainActor actor)
        {
            string _quoteId = string.Empty;
            bool _firstrun = true;

            this.IsBusy = true;
            this.IsEnabled = false;

            try
            {
                string characterName = actor.CharacterName;
                if (actor.CharacterName.Contains("Dr."))
                    characterName = actor.CharacterName.Replace("Dr.", "");
                else
                    characterName = actor.CharacterName.Replace("\"", "%22");

                var quotes = await quotesData.LoadAsyncCharacterName(characterName);
                var quotesC = quotes.Cast<Quote>().ToList();
                IList<ActorQuoteList> _QuoteList = new ObservableCollection<ActorQuoteList>();

                foreach (var item in quotesC.OrderBy(q => q.QuoteId).ThenBy(q => q.LineNo))
                {
                    if (_firstrun)
                    {
                        _firstrun = false;
                        _quoteId = item.QuoteId;
                    }
                    if (_quoteId != item.QuoteId)
                    {
                        var _Quote = new ActorQuoteList();
                        _Quote.ActorId = actor.Id;
                        _Quote.QuoteID = item.QuoteId;
                        _Quote.QuoteText = item.QuoteText;

                        var _episode = await episodeData.LoadAsyncId(item.EpisodeId);
                        if (_episode != null)
                        {
                            _Quote.EpisodeId = _episode.EpisodeId;
                            _Quote.EpisodeText = string.Format("{0} ({1})", _episode.Title, _episode.EpisodeId);

                        }
                        _QuoteList.Add(_Quote);
                        _quoteId = item.QuoteId;
                    }
                }
                foreach (var item in _QuoteList.OrderBy(e => e.EpisodeId))
                    actorQuoteList.Add(item);

                BindingContext = actorQuoteList;
                this.QuotesSectionHeader.Text = string.Format("Quotes ({0})", actorQuoteList.Count().ToString());
            }
            finally
            {
                this.IsBusy = false;
                this.IsEnabled = true;
            }
        }

        void OnItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            ActorQuoteList _actorQuoteList = (ActorQuoteList)e.Item;

            var navPage = new QuotePage(_actorQuoteList.QuoteID);
            //navPage.Title = episode.Title;

            Navigation.PushAsync(navPage);
        }
    }
}

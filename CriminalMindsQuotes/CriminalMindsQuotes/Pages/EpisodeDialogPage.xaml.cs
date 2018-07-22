using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using Xamarin.Forms;
using CriminalMindsQuotes.Data;

namespace CriminalMindsQuotes.Pages
{
    public partial class EpisodeDialogPage : ContentPage
    {
        IList<QuoteList> quotes = new ObservableCollection<QuoteList>();
        QuotesData quoteData = new QuotesData();

        public EpisodeDialogPage(string id)
        {
            InitializeComponent();

            LoadData(id);
        }

        async void LoadData(string id)
        {
            this.IsBusy = true;
            try
            {
                var quoteC = await quoteData.LoadAsyncEpisodeId(id);
                var quotesC = quoteC.Cast<Quote>().ToList();
                string _quote = string.Empty;
                string _quoteId = string.Empty;
                bool _firstrun = true;

                var quotesOC = quotesC.OrderBy(x => x.QuoteId).ThenBy(x => x.LineNo).ToList();

                foreach (var item in quotesOC)
                {
                    if (_firstrun)
                    {
                        _firstrun = false;
                        _quoteId = item.QuoteId;
                    }
                    if (_quoteId != item.QuoteId || string.IsNullOrEmpty(item.QuoteId))
                    {
                        var _Quote = new QuoteList();
                        _Quote.QuoteId = item.QuoteId;
                        _Quote.QuoteText = _quote;
                        this.quotes.Add(_Quote);
                        _quote = string.Empty;
                        _quoteId = item.QuoteId;
                    }

                    if (item.CharacterName == null || item.CharacterName == string.Empty)
                    {
                        if (string.IsNullOrEmpty(item.PostText) == false)
                        {
                            _quote += string.Format("<i>{0}</i><br/>", item.PostText);
                        }
                    }
                    else
                    {
                        if (item.PreText == null || item.PreText == string.Empty)
                        {
                            _quote += string.Format("<b>{0}:</b> {1}<br/>", item.CharacterName, item.QuoteText);
                        }
                        else
                        {
                            _quote += string.Format("<b>{0}:</b> <i>{1}</i> {2}<br/>", item.CharacterName, item.PreText, item.QuoteText);
                        }
                        if (string.IsNullOrEmpty(item.PostText) == false)
                        {
                            _quote += string.Format("<i>{0}</i><br/>", item.PostText);
                        }
                    }
                }
                if (string.IsNullOrEmpty(_quote) == false)
                {
                    var _Quote = new QuoteList();
                    _Quote.QuoteText = _quote;
                    this.quotes.Add(_Quote);
                }

                this.oDialog.Text = string.Format("Other Dialogues ({0})", this.quotes.Count());
                // Create WebView source
                string htmlC = string.Empty;

                foreach (var item in this.quotes)
                {
                    htmlC += item.QuoteText;
                    htmlC += "<br>";
                }

                var htmlSource = new HtmlWebViewSource();
                htmlSource.Html = string.Format("<body style=\"font-family:verdana;\">{0}</body>", htmlC);

                this.HTMLView.Source = htmlSource;
            }
            finally
            {
                this.IsBusy = false;
            }
        }
    }
}

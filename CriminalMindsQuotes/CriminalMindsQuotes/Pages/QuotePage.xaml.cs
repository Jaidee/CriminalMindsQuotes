using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using Xamarin.Forms;
using CriminalMindsQuotes.Data;

namespace CriminalMindsQuotes.Pages
{
    public partial class QuotePage : ContentPage
    {
        QuotesData quoteData = new QuotesData();
        EpisodeData episodeData = new EpisodeData();

        public QuotePage(string quoteId)
        {
            InitializeComponent();

            LoadData(quoteId);
        }

        async void LoadData(string quoteId)
        {
            this.IsBusy = true;
            try
            {
                var quoteLines = await quoteData.LoadAsyncQuoteId(quoteId);
                var quoteLinesC = quoteLines.Cast<Quote>().ToList();

                string _quote = string.Empty;
                string episodeId = string.Empty;

                foreach (var item in quoteLinesC)
                {
                    if (string.IsNullOrEmpty(item.CharacterName))
                    {
                        if (string.IsNullOrEmpty(item.PostText) == false)
                        {
                            _quote += string.Format("<i>{0}</i><br/>", item.PostText);
                        }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(item.PreText))
                        {
                            _quote += string.Format("<b>{0}:</b> {1}<br/>", item.CharacterName, item.QuoteText);
                        }
                        else
                        {
                            _quote += string.Format("<b>{0}:</b> <i>{1}</i> {2}<br/>", item.CharacterName, item.PreText, item.QuoteText);
                        }
                        if (string.IsNullOrEmpty(item.PostText) == false)
                        {

                        }
                    }
                    episodeId = item.EpisodeId;
                }
                var _episode = await episodeData.LoadAsyncId(episodeId);

                var htmlSource = new HtmlWebViewSource();
                htmlSource.Html = string.Format("<body style=\"font-family:verdana;\">{0}</body>", _quote);

                this.lblTitle.Text = _episode.Title;
                this.lblSubtitle.Text = string.Format("({0})", _episode.EpisodeId);
                this.HTMLView.Source = htmlSource;
            }
            finally
            {
                this.IsBusy = false;
            }
        }
    }
}

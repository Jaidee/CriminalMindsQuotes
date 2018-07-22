using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace CriminalMindsQuotes.Pages
{
    public partial class EpisodeQuotesPage : ContentPage
    {
        public EpisodeQuotesPage(Episode episode)
        {
            InitializeComponent();

            BuildQuotes(episode);
        }

        void BuildQuotes(Episode episode)
        {
            this.Quote1Text.Text = episode.Quote_01;
            this.Quote1Author.Text = "- " + episode.Quote_01_Author;
            this.Quote1QuotedBy.Text =
                    string.Format("Quoted by: {0}", episode.Quote_01_By);

            if (episode.Quote_02 == null || episode.Quote_02 == string.Empty)
            {
                this.Quote2Text.Text = string.Empty;
                this.Quote2Author.Text = string.Empty;
                this.Quote2QuotedBy.Text = string.Empty;
            }
            else
            {
                this.Quote2Text.Text = episode.Quote_02;
                this.Quote2Author.Text = "- " + episode.Quote_02_Author;
                this.Quote2QuotedBy.Text =
                    string.Format("Quoted by: {0}", episode.Quote_02_By);
            }
        }
    }
}

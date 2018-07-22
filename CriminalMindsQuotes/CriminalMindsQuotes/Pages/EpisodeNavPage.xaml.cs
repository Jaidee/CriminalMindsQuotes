using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using CriminalMindsQuotes.Data;

namespace CriminalMindsQuotes.Pages
{
    public partial class EpisodeNavPage : TabbedPage
    {
        Episode episode = new Episode();
        EpisodeData episodeData = new EpisodeData();

        public EpisodeNavPage(string id)
        {
            InitializeComponent();

            LoadData(id);
        }

        public async void LoadData(string id)
        {
            episode = await episodeData.LoadAsyncId(id);
             
            Children.Add(new EpisodeQuotesPage(episode));
            Children.Add(new EpisodePlotPage(episode));
            Children.Add(new EpisodeDialogPage(episode.Id));
            Children.Add(new GuestActorsPage(episode.Id));
        }
    }
}
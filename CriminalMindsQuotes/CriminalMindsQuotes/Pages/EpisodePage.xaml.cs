using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using CriminalMindsQuotes.Data;

namespace CriminalMindsQuotes.Pages
{
    public partial class EpisodePage : ContentPage
    {
        ObservableCollection<EpisodeList> episodeList = new ObservableCollection<EpisodeList>();
        EpisodeData episodeData = new EpisodeData();

        public EpisodePage()
        {
            InitializeComponent();

            // NavigationPage.SetBackButtonTitle(this, "");

            LoadData();

        }

        public async void LoadData()
        {
            this.IsBusy = true;
            this.IsEnabled = false;
            try
            {
                var episodeDataColl = await episodeData.LoadAllAsync();

                foreach (var item in episodeDataColl.OrderBy(x => x.EpisodeId))
                    episodeList.Add(new EpisodeList(item.Id, item.EpisodeId, item.Title, item.AirDate));

                BindingContext = new ObservableCollection<Grouping<string, EpisodeList>>(
                    episodeList
                    .OrderBy(e => e.EpisodeKey)
                    .GroupBy(e => e.EpisodeKey.Substring(7, 2))
                    .Select(g => new Grouping<string, EpisodeList>(g.Key, g))
                );
            }
            finally
            {
                this.IsBusy = false;
                this.IsEnabled = true;
            }
        }

        void OnRefreshing(object sender, System.EventArgs e)
        {
            LoadData();
        }

        void OnItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            EpisodeList episode = (EpisodeList)e.Item;

            var navPage = new EpisodeNavPage(episode.Id);
            navPage.Title = episode.Title;

            Navigation.PushAsync(navPage);
        }

        public class Grouping<K, T> : ObservableCollection<T>
        {
            public K Key { get; private set; }
            public Grouping(K key, IEnumerable<T> items)
            {
                Key = key;
                foreach (var item in items)
                    this.Items.Add(item);
            }
        }
    }
}

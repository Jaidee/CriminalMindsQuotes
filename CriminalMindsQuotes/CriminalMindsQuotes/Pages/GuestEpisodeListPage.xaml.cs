using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using CriminalMindsQuotes.Data;

namespace CriminalMindsQuotes.Pages
{
    public partial class GuestEpisodeListPage : ContentPage
    {
        IList<EpisodeList> episodeList = new ObservableCollection<EpisodeList>();
        GuestActorData guestActorData = new GuestActorData();
        EpisodeData episodeData = new EpisodeData();

        public GuestEpisodeListPage(MainActor mainActor)
        {
            InitializeComponent();

            NavigationPage.SetBackButtonTitle(this, "Back");

            LoadData(mainActor);
        }

        public async void LoadData(MainActor actor)
        {
            this.IsBusy = true;

            try
            {
                string characterName = actor.CharacterName;
                if (actor.CharacterName.Contains("Jr."))
                    characterName = actor.CharacterName.Replace("Jr.", "");
                else
                    characterName = actor.CharacterName.Replace("\"", "%22");

                var actors = await guestActorData.LoadAsyncCharacterName(characterName);
              
                IList<EpisodeListItem> _EpisodeList = new ObservableCollection<EpisodeListItem>();

                foreach (var item in actors)
                {
                    Episode _episode = await episodeData.LoadAsyncId(item.EpisodeId);
                    if (_episode != null)
                    {
                        var listItem = new EpisodeListItem();
                        listItem.Id = _episode.Id;
                        listItem.EpisodeId =_episode.EpisodeId;
                        listItem.Title = _episode.Title;
                        listItem.AirDate = _episode.AirDate;

                        _EpisodeList.Add(listItem);
                    }
                }
                foreach (var item in _EpisodeList.OrderBy(e => e.EpisodeId))
                {
                    episodeList.Add(new EpisodeList(
                        item.Id,
                        item.EpisodeId,
                        item.Title,
                        item.AirDate
                    ));
                }

                BindingContext = episodeList;
                this.EpisodeListHeader.Text = string.Format("Episodes ({0})", episodeList.Count().ToString());
            }
            finally
            {
                this.IsBusy = false;
            }
        }

        void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            EpisodeList _episodeList = (EpisodeList)e.Item;

            var navPage = new EpisodeNavPage(_episodeList.Id);
            navPage.Title = _episodeList.Title;

            Navigation.PushAsync(navPage);
        }
    }
}

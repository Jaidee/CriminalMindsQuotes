using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using Xamarin.Forms;
using CriminalMindsQuotes.Data;

namespace CriminalMindsQuotes.Pages
{
    public partial class GuestActorsPage : ContentPage
    {
        GuestActorData guestActorData = new GuestActorData();
        ObservableCollection<GuestActor> guestActors = new ObservableCollection<GuestActor>();

        public GuestActorsPage(string id)
        {
            InitializeComponent();
            LoadData(id);
        }

        private async void LoadData(string id)
        {
            var guestActorsColl = await guestActorData.LoadAsyncEpisodeId(id);
        //    var guestActorsCast = guestActorsColl.Cast<GuestActor>().ToList();

            foreach (var item in guestActorsColl.OrderByDescending(g => g.GuestType))
            {
                var gActor = new GuestActor();

                gActor.Id = item.Id;
                gActor.EpisodeId = item.EpisodeId;
                gActor.CharacterName = item.CharacterName;
                gActor.ActorName = item.ActorName;
                gActor.ImdbActorLink = item.ImdbActorLink;
                gActor.CreatedAt = item.CreatedAt;
                gActor.UpdatedAt = item.UpdatedAt;

                if (item.GuestType.Contains("R"))
                    gActor.GuestType = "Recurring";
                else
                    gActor.GuestType = "Guest";

                guestActors.Add(gActor);
            }

            BindingContext = new ObservableCollection<Grouping<string, GuestActor>>(
                guestActors
                .OrderByDescending(g => g.GuestType)
                .GroupBy(g => g.GuestType)
                .Select(g => new Grouping<string, GuestActor>(g.Key, g))
            );
        }

        void OnItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            GuestActor guestActor = (GuestActor)e.Item;

            Device.OpenUri(new Uri(guestActor.ImdbActorLink));

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

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using Xamarin.Forms;
using CriminalMindsQuotes.Data;

namespace CriminalMindsQuotes.Pages
{
    public partial class RecurActorsPage : ContentPage
    {
        IList<MainActor> recurActors = new ObservableCollection<MainActor>();
        MainActorData recurActorData = new MainActorData();

        public RecurActorsPage()
        {
            InitializeComponent();

            //NavigationPage.SetBackButtonTitle(this, "Back");

            LoadData();
        }

        public async void LoadData()
        {
            this.IsBusy = true;
            this.IsEnabled = false;
            try
            {
                var mainActorColl = await recurActorData.LoadAllAsync();

                foreach (var item in mainActorColl.Where(x => x.CharacterType == "R"))
                    recurActors.Add(item);

                BindingContext = recurActors;

            }
            finally
            {
                this.IsBusy = false;
                this.IsEnabled = true;
            }
        }

        void OnItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            MainActor actor = (MainActor)e.Item;

            var navPage = new ActorNavPage(actor.Id);
            navPage.Title = actor.CharacterName;

            Navigation.PushAsync(navPage);
        }
    }
}

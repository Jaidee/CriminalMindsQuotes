using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
            
using Xamarin.Forms;
using CriminalMindsQuotes.Data;

namespace CriminalMindsQuotes.Pages
{
    public partial class MainActorPage : ContentPage
    {
        IList<MainActor> mainActors = new ObservableCollection<MainActor>();
        MainActorData mainActorData = new MainActorData();

        public MainActorPage()
        {
            InitializeComponent();

          //  NavigationPage.SetBackButtonTitle(this, "");

            LoadData();
        }

        public async void LoadData()
        {
            this.IsBusy = true;
            this.IsEnabled = false;
            try
            {
                var mainActorColl = await mainActorData.LoadAllAsync();

                foreach (var item in mainActorColl.Where(x => x.CharacterType == "M"))
                    mainActors.Add(item);

                BindingContext = mainActors;

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

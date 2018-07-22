using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace CriminalMindsQuotes.Pages
{
    public partial class ActorPage : ContentPage
    {
        MainActor _mainActor;

        public ActorPage(MainActor mainActor)
        {
            InitializeComponent();

            this._mainActor = mainActor;

            BindingContext = mainActor;

            this.ActorWebLink.Text = string.Format("More about {0} on IMDB", mainActor.ActorName);
        }

        void OnActorWebLinkTapped(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri(_mainActor.ImdbActorLink));
        }
    }
}

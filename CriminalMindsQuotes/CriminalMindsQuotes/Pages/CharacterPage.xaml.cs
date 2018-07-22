using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace CriminalMindsQuotes.Pages
{
    public partial class CharacterPage : ContentPage
    {
        MainActor _mainActor;

        public CharacterPage(MainActor mainActor)
        {
            InitializeComponent();

            this._mainActor = mainActor;

            BindingContext = mainActor;

            this.CharWebLink.Text = string.Format("More about {0} on IMDB", mainActor.CharacterName);

        }

        void OnCharWebLinkTapped(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri(_mainActor.ImdbCharLink));
        }
    }
}

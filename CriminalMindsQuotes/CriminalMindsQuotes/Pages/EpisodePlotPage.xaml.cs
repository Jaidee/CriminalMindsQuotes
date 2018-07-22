using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace CriminalMindsQuotes.Pages
{
    public partial class EpisodePlotPage : ContentPage
    {
        public EpisodePlotPage(Episode episode)
        {
            InitializeComponent();

            BindingContext = episode;
        }
    }
}

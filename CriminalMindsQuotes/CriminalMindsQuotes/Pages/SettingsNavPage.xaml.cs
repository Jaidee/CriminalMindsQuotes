using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace CriminalMindsQuotes.Pages
{
    public partial class SettingsNavPage : TabbedPage
    {
        public SettingsNavPage()
        {
            InitializeComponent();

            Children.Add(new SettingsPage());
            Children.Add(new PrivarcyPage());
        }
    }
}

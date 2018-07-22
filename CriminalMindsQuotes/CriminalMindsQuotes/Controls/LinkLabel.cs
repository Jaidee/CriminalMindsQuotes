using System;
using Xamarin.Forms;

namespace CriminalMindsQuotes.Controls
{
    public class LinkLabel : Label
    {
        public LinkLabel(Uri uri, string labelText = null)
        {
            Text = labelText ?? uri.ToString();
            GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(()=> Device.OpenUri(uri))
            });
        }
    }
}

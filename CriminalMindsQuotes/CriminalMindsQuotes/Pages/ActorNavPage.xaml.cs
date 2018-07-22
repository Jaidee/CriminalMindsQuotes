using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using CriminalMindsQuotes.Data;

namespace CriminalMindsQuotes.Pages
{
    public partial class ActorNavPage : TabbedPage
    {
        MainActor mainActor = new MainActor();
        MainActorData mainActorData = new MainActorData();

        public ActorNavPage(string id)
        {
            InitializeComponent();

            LoadData(id);
        }

        public async void LoadData(string id)
        {
            mainActor = await mainActorData.LoadAsyncActorId(id);

            Children.Add(new CharacterPage(mainActor));
            Children.Add(new ActorPage(mainActor));
            if (mainActor.CharacterType == "M")
                Children.Add(new ActorQuotePage(mainActor));
            if (mainActor.CharacterType == "R")
                Children.Add(new GuestEpisodeListPage(mainActor));
        }
    }
}

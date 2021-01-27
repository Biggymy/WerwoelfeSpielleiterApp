using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Werwoelfe
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayerDetailPage : ContentPage
    {
        private Player _player;
        private SQLiteAsyncConnection _SQLite;

        public PlayerDetailPage()
        {
            InitializeComponent();
            _player = PlayerPage.CurrentPlayer;
            BindingContext = _player;
            _SQLite = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        protected override async void OnAppearing()
        {
            await _SQLite.CreateTableAsync<Player>();

            base.OnAppearing();
        }

        private async void Save_Clicked(object sender, EventArgs e)
        {
            await _SQLite.UpdateAsync(_player);
            await Navigation.PopAsync();
        }

        protected override bool OnBackButtonPressed()
        {
            return base.OnBackButtonPressed();
        }
    }
}

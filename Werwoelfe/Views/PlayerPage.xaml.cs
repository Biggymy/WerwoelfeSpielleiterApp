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
    public partial class PlayerPage : ContentPage
    {
        public static Player CurrentPlayer { get; set; }
        private SQLiteAsyncConnection _SQLite;
        public ObservableCollection<Player> _player;
        public PlayerPage()
        {
            InitializeComponent();

            _SQLite = DependencyService.Get<ISQLiteDb>().GetConnection();
        }
        protected async override void OnAppearing()
        {
            await _SQLite.CreateTableAsync<Player>();
            var SQLitePlayer = await _SQLite.Table<Player>().ToListAsync();
            _player = new ObservableCollection<Player>(SQLitePlayer);

            PlayerList.ItemsSource = _player;

            base.OnAppearing();
        }
        private async void NewPlayer_Clicked(object sender, EventArgs e)
        {
            CurrentPlayer = new Player();
            await Shell.Current.GoToAsync("PlayerDetailPage");
        }

        private async void DeletePlayer_Clicked(object sender, EventArgs e)
        {
            CurrentPlayer = ((sender as MenuItem).CommandParameter as Player);
            _player.Remove(CurrentPlayer);
            await _SQLite.DeleteAsync(CurrentPlayer);
        }

        private async void ChangePlayer_Clicked(object sender, EventArgs e)
        {
            CurrentPlayer = ((sender as MenuItem).CommandParameter as Player);
            await Shell.Current.GoToAsync("PlayerDetailPage");
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {

        }
    }
}
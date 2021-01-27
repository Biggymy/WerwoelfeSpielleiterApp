using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Werwoelfe
{
    public class Player : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        private bool _isFavorite;
        private string _name = "Player1";
        private bool _isSelected;

        public Player()
        {
        }

        public bool IsFavorite
        {
            get { return _isFavorite; }
            set
            {
                if (IsFavorite == value) return;
                _isFavorite = value;

                OnPropertyChanged();
            }
        }

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (IsSelected == value) return;
                _isSelected = value;

                OnPropertyChanged();
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (Name == value) return;
                _name = value;

                OnPropertyChanged();
            }
        }

        private void OnPropertyChanged([CallerMemberName]string propertyName=null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

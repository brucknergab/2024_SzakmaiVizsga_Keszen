using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WpfApplication
{
    public class Futo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _nev;
        public string Nev
        {
            get => _nev;
            set
            {
                _nev = value;
                OnPropertyChanged(nameof(Nev));
            }
        }

        private double _ido;
        public double Ido
        {
            get => _ido;
            set
            {
                _ido = value;
                OnPropertyChanged(nameof(Ido));
            }
        }
        private int _tav;
        public int Tav
        {
            get => _tav;
            set
            {
                _tav = value;
                OnPropertyChanged(nameof(Tav));
            }
        }

    }
}
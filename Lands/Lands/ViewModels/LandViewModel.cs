namespace Lands.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using Lands.Models;
    public class LandViewModel : INotifyPropertyChanged
    {
        #region Atributes
        public ObservableCollection<Border> _borders;
        public ObservableCollection<Currency> _currencies;
        public ObservableCollection<Language> _languagues;
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Properties
        public Land Land
        {
            get;
            set;
        }

        public ObservableCollection<Border> Borders
        {
            get
            {
                return _borders;
            }
            set
            {
                _borders = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Currency> Currencies
        {
            get
            {
                return _currencies;
            }
            set
            {
                _currencies = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Language> Languagues
        {
            get
            {
                return _languagues;
            }
            set
            {
                _languagues = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Constructors
        public LandViewModel(Land land)
        {
            this.Land = land;
            this.LoadBorders();
            this.Currencies = new ObservableCollection<Currency>(this.Land.Currencies);
            this.Languagues = new ObservableCollection<Language>(this.Land.Languages);
        }


        #endregion

        #region Methods
        private void OnPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void LoadBorders()
        {
            this.Borders = new ObservableCollection<Border>();
            foreach (var border in this.Land.Borders)
            {
                var land = MainViewModel.GetInstance().LandsList.
                                        Where(lst => lst.Alpha3Code == border).
                                        FirstOrDefault();
                if (land != null)
                {
                    this.Borders.Add(new Border
                    {
                        Code = land.Alpha3Code,
                        Name = land.Name,
                    }
                    );
                }
            }
        }
        #endregion
    }
}

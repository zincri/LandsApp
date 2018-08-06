namespace Lands.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Lands.Models;
    using Lands.Services;
    public class LandsViewModel : INotifyPropertyChanged
    {
        #region Services
        private ApiService apiService;
        #endregion

        #region Atributes
        private ObservableCollection<LandItemViewModel> _lands;
        private bool _isRefreshing;
        private string _filter;

        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Properties
        public ObservableCollection<LandItemViewModel> Lands
        {
            get
            {
                return _lands;
            }
            set
            {
                _lands = value;
                OnPropertyChanged();
            }
        }
        public bool IsRefreshing
        {
            get
            {
                return _isRefreshing;
            }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged();
            }
        }
        public string Filter
        {
            get
            {
                return _filter;
            }
            set
            {
                _filter = value;
                OnPropertyChanged();
                Search();
            }
        }
        #endregion

        #region Constructors
        public LandsViewModel()
        {
            this.apiService = new ApiService();
            this.LoadLands();

        }
        #endregion

        #region Methods
        private async void LoadLands()
        {
            this.IsRefreshing = true;
            //http://restcountries.eu/rest/v2/all
            var connection = await this.apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                this.IsRefreshing = false;
                await App.Current.MainPage.DisplayAlert("Error", connection.Message, "Accept");
                await App.Current.MainPage.Navigation.PopAsync();
                return;

            }
            var response = await this.apiService.GetList<Land>("http://restcountries.eu", "/rest", "/v2/all");
            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;
                await App.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
                await App.Current.MainPage.Navigation.PopAsync();
                return;
            }

            MainViewModel.GetInstance().LandsList = (List<Land>)response.Result;
            this.IsRefreshing = false;
            this.Lands = new ObservableCollection<LandItemViewModel>(
                this.ToLandItemViewModel());

        }

        private void OnPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private void Search()
        {
            if (string.IsNullOrEmpty(this.Filter))
            {
                this.Lands = new ObservableCollection<LandItemViewModel>(
                    this.ToLandItemViewModel()
                );
            }
            else
            {
                this.Lands = new ObservableCollection<LandItemViewModel>(
                    this.ToLandItemViewModel().Where(
                        lst => lst.Name.ToLower().Contains(this.Filter.ToLower()) ||
                        lst.Capital.ToLower().Contains(this.Filter.ToLower())
                    )
                );
            }
        }

        private IEnumerable<LandItemViewModel> ToLandItemViewModel()
        {
            return MainViewModel.GetInstance().LandsList.Select(landlst => new LandItemViewModel
            {
                Alpha2Code = landlst.Alpha2Code,
                Alpha3Code = landlst.Alpha3Code,
                AltSpellings = landlst.AltSpellings,
                Area = landlst.Area,
                Borders = landlst.Borders,
                CallingCodes = landlst.CallingCodes,
                Capital = landlst.Capital,
                Cioc = landlst.Cioc,
                Currencies = landlst.Currencies,
                Demonym = landlst.Demonym,
                Flag = landlst.Flag,
                Gini = landlst.Gini,
                Languages = landlst.Languages,
                Latlng = landlst.Latlng,
                Name = landlst.Name,
                NativeName = landlst.NativeName,
                NumericCode = landlst.NumericCode,
                Population = landlst.Population,
                Region = landlst.Region,
                RegionalBlocs = landlst.RegionalBlocs,
                Subregion = landlst.Subregion,
                Timezones = landlst.Timezones,
                TopLevelDomain = landlst.TopLevelDomain,
                Translations = landlst.Translations,

            });

        }
        #endregion

        #region Commands
        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadLands);
            }
        }
        public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand(Search);
            }
        }

        #endregion
    }
}

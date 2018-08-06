namespace Lands.ViewModels
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;
    using Lands.Services;
    using GalaSoft.MvvmLight.Command;
    using Lands.Helpers;
    public class LoginViewModel : INotifyPropertyChanged
    {
        #region Services
        private ApiService apiService;
        #endregion
        private string _email;
        private string _password;
        private bool _isRunning;
        private bool _isRemembered;
        private bool _isEnable;
        public event PropertyChangedEventHandler PropertyChanged;
        #region Properties
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }
        public bool IsRunning
        {
            get
            {
                return _isRunning;
            }
            set
            {
                _isRunning = value;
                OnPropertyChanged();
            }
        }
        public bool IsRemembered
        {
            get
            {
                return _isRemembered;
            }
            set
            {
                _isRemembered = value;
                OnPropertyChanged();
            }
        }
        public bool IsEnable
        {
            get
            {
                return _isEnable;
            }
            set
            {
                _isEnable = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Constructors
        public LoginViewModel()
        {
            this.apiService = new ApiService();
            IsEnable = true;

            Email = "zincri_mlz@hotmail.com";
            Password = "123456";

            IsRemembered = true;
            IsRunning = false;



        }
        #endregion

        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(LoginMethod);
            }
        }
        #endregion

        #region Methods
        private async void LoginMethod()
        {
            IsRunning = true;
            IsEnable = false;
            if (string.IsNullOrEmpty(this.Email))
            {
                await App.Current.MainPage.DisplayAlert(
                Languages.Error,
                Languages.EmailValidation,
                Languages.Ok);
                this.Password = string.Empty;
                IsRunning = false;
                IsEnable = true;
                return;
            }
            if (string.IsNullOrEmpty(this.Password))
            {
                await App.Current.MainPage.DisplayAlert(
                Languages.Error,
                Languages.PasswordValidation,
                Languages.Ok);
                this.Password = string.Empty;
                IsRunning = false;
                IsEnable = true;
                return;
            }


            var conection = await this.apiService.CheckConnection();
            if (!conection.IsSuccess)
            {

                IsRunning = false;
                IsEnable = true;
                await App.Current.MainPage.DisplayAlert(
                Languages.Error,
                    conection.Message,
                Languages.Ok);
                this.Password = string.Empty;
                return;
            }
            var token = await this.apiService.GetToken(
                "http://landsapi1.azurewebsites.net",
                this.Email,
                this.Password);

            /******************************TEMPORAL**********************************/
            if(this.Email != "zincri_mlz@hotmail.com" && this.Password!="123456")
            {
                IsRunning = false;
                IsEnable = true;
                await App.Current.MainPage.DisplayAlert(
                Languages.Error,
                Languages.SomethingWrong,
                Languages.Ok);
                this.Password = string.Empty;
                return;
                
            }
            /******************************TEMPORAL**********************************/

            /*
            if (token == null)
            {
                IsRunning = false;
                IsEnable = true;
                await App.Current.MainPage.DisplayAlert(
                Languages.Error,
                Languages.SomethingWrong,
                Languages.Ok);
                this.Password = string.Empty;
                return;

            }
            if (string.IsNullOrEmpty(token.AccessToken))
            {
                IsRunning = false;
                IsEnable = true;
                await App.Current.MainPage.DisplayAlert(
                Languages.Error,
                    token.ErrorDescription,
                Languages.Ok);
                this.Password = string.Empty;
                return;
            }*/

            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.Token = token;

            mainViewModel.Lands = new LandsViewModel();
            await App.Current.MainPage.Navigation.PushAsync(new Views.LandsPage());

            IsRunning = false;
            IsEnable = true;
            Password = string.Empty;

        }

        private void OnPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}

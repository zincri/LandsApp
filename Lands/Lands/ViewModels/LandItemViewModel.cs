namespace Lands.ViewModels
{
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Lands.Models;
    using Lands.Views;
    public class LandItemViewModel : Land
    {

        public LandItemViewModel()
        {

        }

        #region Commands
        public ICommand SelectLandCommand
        {
            get
            {
                return new RelayCommand(SelectLand);
            }
        }
        #endregion
        #region Methods
        private async void SelectLand()
        {
            MainViewModel.GetInstance().Land = new LandViewModel(this);
            //await App.Current.MainPage.Navigation.PushAsync(new LandPage());
            await App.Current.MainPage.Navigation.PushAsync(new LandTabbedPage());
        }
        #endregion
    }
}

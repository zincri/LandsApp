namespace Lands.Helpers
{
    using Lands.Interfaces;
    using Lands.Resources;

    using Xamarin.Forms;

    public static class Languages
    {
        static Languages()
        {
            var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            Resource.Culture = ci;
            DependencyService.Get<ILocalize>().SetLocale(ci);
        }

        public static string Ok
        {
            get { return Resource.Ok; }
        }

        public static string EmailValidation
        {
            get { return Resource.EmailValidation; }
        }

        public static string PasswordValidation
        {
            get { return Resource.PasswordValidation; }
        }

        public static string SomethingWrong
        {
            get { return Resource.SomethingWrong; }
        }

        public static string Rememberme
        {
            get { return Resource.Rememberme; }
        }

        public static string EmailPlaceHolder
        {
            get { return Resource.EmailPlaceHolder; }
        }

        public static string Error
        {
            get { return Resource.Error; }
        }

        public static string PasswordPlaceHolder
        {
            get { return Resource.PasswordPlaceHolder; }
        }

        public static string ForgotPassword
        {
            get { return Resource.ForgotPassword; }
        }

        public static string Login
        {
            get { return Resource.Login; }
        }

        public static string LoginTitle
        {
            get { return Resource.LoginTitle; }
        }

        public static string LandsTitle
        {
            get { return Resource.LandsTitle; }
        }

        public static string LandTitle
        {
            get { return Resource.LandTitle; }
        }

        public static string Search
        {
            get { return Resource.Search; }
        }

        public static string Register
        {
            get { return Resource.Register; }
        }

        public static string Information
        {
            get { return Resource.Information; }
        }

        //*************************************************************
        public static string Capital
        {
            get { return Resource.Capital; }
        }

        public static string Population
        {
            get { return Resource.Population; }
        }

        public static string Area
        {
            get { return Resource.Area; }
        }

        public static string AlphaCode2
        {
            get { return Resource.AlphaCode2; }
        }

        public static string AlphaCode3
        {
            get { return Resource.AlphaCode3; }
        }

        public static string Region
        {
            get { return Resource.Region; }
        }

        public static string Subregion
        {
            get { return Resource.Subregion; }
        }

        public static string Demonym
        {
            get { return Resource.Demonym; }
        }

        public static string GINI
        {
            get { return Resource.GINI; }
        }

        public static string NativeName
        {
            get { return Resource.NativeName; }
        }

        public static string NumericCode
        {
            get { return Resource.NumericCode; }
        }

        public static string CIOC
        {
            get { return Resource.CIOC; }
        }
        //*************************************************************

        public static string Borders
        {
            get { return Resource.Borders; }
        }

        public static string Currencies
        {
            get { return Resource.Currencies; }
        }

        public static string MyLanguages
        {
            get { return Resource.MyLanguages; }
        }

        public static string Translations
        {
            get { return Resource.Translations; }
        }


    }
}

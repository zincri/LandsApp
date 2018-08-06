using Xamarin.Forms;
using Xamarin.Forms.Xaml;
[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace Lands
{

	public partial class App : Application
	{
		public App ()
		{
            InitializeComponent();
            NavigationPage objeto = new NavigationPage(new Views.LoginPage());
            //objeto.BarBackgroundColor=Color.FromHex("#DE31AA");
            objeto.BarBackgroundColor = Color.FromHex("#004475");
            objeto.BarTextColor = Color.FromHex("#37d472");
            MainPage = objeto;
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

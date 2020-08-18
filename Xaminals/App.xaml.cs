using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HaruhiSuzumiya.APP.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace HaruhiSuzumiya
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            //MainPage = new SplashPage();
            var splashPage = new SplashPage();
            //var nav = new NavigationPage(splashPage);
            //this.MainPage = nav;
          
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            Console.WriteLine("OnStart");
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
            Console.WriteLine("OnSleep");
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
            Console.WriteLine("OnResume");
        }

    }
}

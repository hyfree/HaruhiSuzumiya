using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
namespace HaruhiSuzumiya.APP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SplashPage : ContentPage
    {
        private App app;
        private Task startupWork = null;
        public void SetAPP(App oneApp)
        {
            app = oneApp;

        }
        public SplashPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            Console.WriteLine("hello");
            if (startupWork == null)
            {
                startupWork = new Task(() => { SimulateStartup(); });
                startupWork.Start();
            }
        }
        protected override void OnDisappearing()
        {

        }

        private async void SimulateStartup()
        {
            await MainThread.InvokeOnMainThreadAsync(async () =>
             {
                 await Task.Delay(3000); // Simulate a bit of startup work.
                 Console.WriteLine("调用SimulateStartup");
                 app.MainPage=new AppShell();
             });
        }



        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
            Navigation.PushAsync(new AppShell());
        }
    }
}
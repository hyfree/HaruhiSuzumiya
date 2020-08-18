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
        public SplashPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            Console.WriteLine("hello");
            Task startupWork = new Task(() => { SimulateStartup(); });
          //  startupWork.Start();

        }  
        protected override void OnDisappearing()
        {

        }
        async void SimulateStartup()
        {
          await  MainThread.InvokeOnMainThreadAsync(async () =>
            {
                await Task.Delay(3000); // Simulate a bit of startup work.
                Console.WriteLine("调用SimulateStartup");
                // await Navigation.PushModalAsync(new AppShell());
                //Navigation.InsertPageBefore(new AppShell(), this);
                //await Navigation.PopAsync();
                //  Navigation.RemovePage(this);
                // Code to run on the main thread
               // await  Navigation.PopAsync();
                await  Navigation.PushAsync(new AppShell());
            });
  
           
           
        }



        private void ImageButton_Clicked(object sender, EventArgs e)
        {
             Navigation.PopAsync();
             Navigation.PushAsync(new AppShell());
        }
    }
}
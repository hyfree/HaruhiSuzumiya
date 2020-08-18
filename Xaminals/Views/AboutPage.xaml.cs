using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HaruhiSuzumiya.APP.Views
{
    public partial class AboutPage : ContentPage
    {
        public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));

        public AboutPage()
        {
            InitializeComponent();
            BindingContext = this;
        }
    }
}

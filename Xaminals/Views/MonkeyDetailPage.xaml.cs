using Xamarin.Forms;
using HaruhiSuzumiya.APP.ViewModels;

namespace HaruhiSuzumiya.APP.Views
{
    public partial class MonkeyDetailPage : ContentPage
    {
        public MonkeyDetailPage()
        {
            InitializeComponent();
            BindingContext = new MonkeyDetailViewModel();
        }
    }
}

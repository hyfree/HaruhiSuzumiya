using Xamarin.Forms;
using HaruhiSuzumiya.ViewModels;

namespace HaruhiSuzumiya.Views
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

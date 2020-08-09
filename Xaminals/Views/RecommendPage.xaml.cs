using System.Linq;
using Xamarin.Forms;
using Xaminals.Models;
using Xaminals.ViewModels;

namespace Xaminals.Views
{
    public partial class RecommendPage : ContentPage
    {
        MainViewModel _vm;
        public RecommendPage()
        {
            InitializeComponent();
            //BindingContext = _vm = new MainViewModel();
        }

        async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string dogName = (e.CurrentSelection.FirstOrDefault() as Animal).Name;
            // This works because route names are unique in this application.
            await Shell.Current.GoToAsync($"dogdetails?name={dogName}");
            // The full route is shown below.
            // await Shell.Current.GoToAsync($"//animals/domestic/dogs/dogdetails?name={dogName}");
        }

        async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            string dogName = (e.Item as Animal).Name;
            // This works because route names are unique in this application.
            await Shell.Current.GoToAsync($"dogdetails?name={dogName}");

        }
    }
}

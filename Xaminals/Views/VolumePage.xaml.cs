using System.Linq;
using Xamarin.Forms;
using HaruhiSuzumiya.APP.Models;
using HaruhiSuzumiya.APP.ViewModels;

namespace HaruhiSuzumiya.APP.Views
{
    public partial class VolumePage : ContentPage
    {
        private readonly MainViewModel _vm;
        public VolumePage()
        {
            InitializeComponent();
            //BindingContext = _vm = new MainViewModel();
        }

        private async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (collectionView.SelectedItem != null)
            {
                string name = (e.CurrentSelection.FirstOrDefault() as Volume).Name;
                name = "Norwegian Buhund";
                await Shell.Current.GoToAsync($"dogdetails?name={name}");
                ((CollectionView)sender).SelectedItem = null;
            }


            // This works because route names are unique in this application.


            // ((CollectionView)sender).SelectedItem = null;
            //if (collectionView.SelectedItem != null)
            //{
            //    collectionView.SelectedItem = null;
            //}
            // The full route is shown below.
            // await Shell.Current.GoToAsync($"//animals/domestic/dogs/dogdetails?name={dogName}");
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            string dogName = (e.Item as Animal).Name;
            // This works because route names are unique in this application.
            await Shell.Current.GoToAsync($"dogdetails?name={dogName}");

        }

        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {

        }
    }
}

using System.Linq;
using Xamarin.Forms;
using HaruhiSuzumiya.APP.Models;
using HaruhiSuzumiya.APP.ViewModels;
using HaruhiSuzumiya.Common.Entity;

namespace HaruhiSuzumiya.APP.Views
{
    public partial class RecommendPage : ContentPage
    {
      
        public RecommendPage()
        {
            InitializeComponent();
           
        }

        async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string animeName = (e.CurrentSelection.FirstOrDefault() as Anime).Name;
            // This works because route names are unique in this application.
            await Shell.Current.GoToAsync($"AnimePlay?name={animeName}");
            // The full route is shown below.
            // await Shell.Current.GoToAsync($"//animals/domestic/dogs/dogdetails?name={dogName}");
        }

        async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            string animeName = (e.Item as Anime).Name;
            // This works because route names are unique in this application.
            await Shell.Current.GoToAsync($"AnimePlay?name={animeName}");

        }
    }
}

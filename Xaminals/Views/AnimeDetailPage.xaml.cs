using FormsVideoLibrary;
using System;
using System.Linq;
using Xamarin.Forms;
using HaruhiSuzumiya.APP.Data;

namespace HaruhiSuzumiya.APP.Views
{
    [QueryProperty("Name", "name")]
    public partial class VideoDetailPage : ContentPage
    {
        public string Name
        {
            set
            {
                BindingContext = DogData.Dogs.FirstOrDefault(m => m.Name == Uri.UnescapeDataString(value));
            }
        }

        public VideoDetailPage()
        {
            InitializeComponent();
            videoPlayer.Source = (UriVideoSource)Application.Current.Resources["ElephantsDream"];
            videoPlayer.Play();
           
        }
    }
}

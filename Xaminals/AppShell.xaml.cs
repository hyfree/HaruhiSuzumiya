using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HaruhiSuzumiya.APP.Data;
using HaruhiSuzumiya.APP.Views;

namespace HaruhiSuzumiya
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
       
        public ICommand NavigateCommand { get; private set; }
        Random rand = new Random();
        Dictionary<string, Type> routes = new Dictionary<string, Type>();
        public Dictionary<string, Type> Routes { get { return routes; } }

        public ICommand HelpCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));
        public ICommand RandomPageCommand => new Command(async () => await NavigateToRandomPageAsync());

   
        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
            NavigateCommand = new Command<Type>(
               async (Type pageType) =>
               {
                   Page page = (Page)Activator.CreateInstance(pageType);
                   await Navigation.PushAsync(page);
               });
            BindingContext = this;
           
        }
           

        void RegisterRoutes()
        {
            routes.Add("monkeydetails", typeof(MonkeyDetailPage));
            routes.Add("beardetails", typeof(BearDetailPage));
            routes.Add("catdetails", typeof(CatDetailPage));
            routes.Add("videodetails", typeof(VideoDetailPage));
            routes.Add("AnimePlay", typeof(AnimePlayPage));
            routes.Add("elephantdetails", typeof(ElephantDetailPage));

            foreach (var item in routes)
            {
                Routing.RegisterRoute(item.Key, item.Value);
            }
        }

        async Task NavigateToRandomPageAsync()
        {
            string destinationRoute = routes.ElementAt(rand.Next(0, routes.Count)).Key;
            string animalName = null;

            switch (destinationRoute)
            {
                case "monkeydetails":
                    animalName = MonkeyData.Monkeys.ElementAt(rand.Next(0, MonkeyData.Monkeys.Count)).Name;
                    break;
                case "beardetails":
                    animalName = BearData.Bears.ElementAt(rand.Next(0, BearData.Bears.Count)).Name;
                    break;
                case "catdetails":
                    animalName = CatData.Cats.ElementAt(rand.Next(0, CatData.Cats.Count)).Name;
                    break;
                case "dogdetails":
                    animalName = DogData.Dogs.ElementAt(rand.Next(0, DogData.Dogs.Count)).Name;
                    break;
                case "elephantdetails":
                    animalName = ElephantData.Elephants.ElementAt(rand.Next(0, ElephantData.Elephants.Count)).Name;
                    break;
            }

            ShellNavigationState state = Shell.Current.CurrentState;
            await Shell.Current.GoToAsync($"{state.Location}/{destinationRoute}?name={animalName}");
            Shell.Current.FlyoutIsPresented = false;
        }
        
        void OnNavigating(object sender, ShellNavigatingEventArgs e)
        {
            // Cancel any back navigation
            //if (e.Source == ShellNavigationSource.Pop)
            //{
            //    e.Cancel();
            //}
        }

        void OnNavigated(object sender, ShellNavigatedEventArgs e)
        {

        }
    }
}

using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin_Module9_TP06
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            NavigationPage main = new NavigationPage(new MainPage());
            MainPage = main;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

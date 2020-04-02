using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin_Module9_TP06.Entities;
using Xamarin_Module9_TP06.Services;

namespace Xamarin_Module9_TP06
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private ITwitterService twitterService;

        public MainPage()
        {
            InitializeComponent();
            this.btnConnexion.Clicked += BtnConnexion_Clicked;
            this.errorLabel.IsVisible = false;
            this.twitterService = new TwitterServiceImpl();
        }

        private void BtnConnexion_Clicked(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("btn clicked");
            String login = this.identifiant.Text;
            String password = this.motDePasse.Text;
            Boolean isRemind = this.memorise.IsToggled;

            String errors = "";

            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                errors = this.twitterService.Authenticate(new User() { Login = login, Password = password });
            }
            else
            {
                errors = "Pas de connection internet disponible";
            }

            if (!String.IsNullOrEmpty(errors))
            {
                this.errorLabel.Text = errors;
                this.errorLabel.IsVisible = true;
            }
            else
            {
                this.errorLabel.Text = "";
                this.errorLabel.IsVisible = false;
                Navigation.PushAsync(new TweetsPage());
            }
        }

        protected override void OnAppearing()
        {
            this.identifiant.Text = "";
            this.motDePasse.Text = "";
            this.memorise.IsToggled = false;
            base.OnAppearing();
        }
    }
}

using ENI_Xamarin_30032020.Data;
using ENI_Xamarin_30032020.Entities;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Text;
using static ENI_Xamarin_30032020.Configurations.ViewModelLocator;

namespace ENI_Xamarin_30032020.ViewModels
{
    public class TweetCreateViewViewModel : ViewModelBase
    {
        private INavigationService navigation;

        public Tweet Tweet { get; set; }

        public RelayCommand ConnectionClicked
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (true)
                    {
                        Tweet.CreationDate = DateTime.Now;
                        using (var db = new AppDbContext())
                        {
                            db.Tweets.Add(Tweet);
                            db.SaveChanges();
                        }
                        this.navigation.NavigateTo(Pages.TweetsPage.ToString());
                    }
                });
            }
        }

        public TweetCreateViewViewModel(INavigationService navigation)
        {
            Messenger.Default.Register<GenericMessage<int>>(this, PageLoaded);
            this.navigation = navigation;
            this.Tweet = new Tweet();
        }

        public void PageLoaded(GenericMessage<int> msg)
        {
            if (msg.Content == 1)
            {
                this.Tweet.Id = 0;
                this.Tweet.Content = "";
            }
        }
    }
}

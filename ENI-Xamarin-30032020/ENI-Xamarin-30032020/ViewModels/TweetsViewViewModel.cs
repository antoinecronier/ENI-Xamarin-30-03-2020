using ENI_Xamarin_30032020.Entities;
using ENI_Xamarin_30032020.Services;
using ENI_Xamarin_30032020.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace ENI_Xamarin_30032020.ViewModels
{
    public class TweetsViewViewModel : ViewModelBase
    {
        private ITwitterService twitterService;

        private ObservableCollection<Tweet> tweets;

        public ObservableCollection<Tweet> Tweets
        {
            get { return tweets; }
            set { tweets = value; }
        }

        public TweetsViewViewModel(ITwitterService twitterService)
        {
            Messenger.Default.Register<GenericMessage<int>>(this, PageLoaded);
            this.twitterService = twitterService;
            this.tweets = new ObservableCollection<Tweet>();
        }

        public void PageLoaded(GenericMessage<int> msg)
        {
            if (msg.Content == 1)
            {
                this.Tweets.Clear();
                var tweets = this.twitterService.Tweets.OrderByDescending(x => x.CreationDate);
                foreach (var item in tweets)
                {
                    this.Tweets.Add(item);
                }
            }
        }
    }
}

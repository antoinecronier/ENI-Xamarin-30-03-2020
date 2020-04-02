using CommonServiceLocator;
using ENI_Xamarin_30032020.Services;
using ENI_Xamarin_30032020.ViewModels;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace ENI_Xamarin_30032020.Configurations
{
    public class ViewModelLocator
    {
        public enum Pages
        {
            MainPage,
            TweetsPage,
            TweetCreatePage
        }

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<INavigationService>(() =>
            {
                var navigationService = NavigationService.Instance;
                navigationService.Configure(Pages.MainPage.ToString(), typeof(MainPage));
                navigationService.Configure(Pages.TweetsPage.ToString(), typeof(TweetsPage));
                navigationService.Configure(Pages.TweetCreatePage.ToString(), typeof(TweetCreatePage));
                return navigationService;
            });

            SimpleIoc.Default.Register<ITwitterService>(() =>
            {
                return new TwitterServiceImpl();
            });

            SimpleIoc.Default.Register<MainPageViewModel>();
            SimpleIoc.Default.Register<TweetsPageViewModel>();

            SimpleIoc.Default.Register<ConnectionViewViewModel>();
            SimpleIoc.Default.Register<FooterViewViewModel>();
            SimpleIoc.Default.Register<HeaderViewViewModel>();
            SimpleIoc.Default.Register<OneTweetViewViewModel>();
            SimpleIoc.Default.Register<TweetsViewViewModel>();
        }


        public MainPageViewModel MainPageViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainPageViewModel>();
            }
        }

        public TweetsPageViewModel TweetsPageViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<TweetsPageViewModel>();
            }
        }

        public ConnectionViewViewModel ConnectionViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ConnectionViewViewModel>();
            }
        }
        public FooterViewViewModel FooterViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<FooterViewViewModel>();
            }
        }
        public HeaderViewViewModel HeaderViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<HeaderViewViewModel>();
            }
        }
        public OneTweetViewViewModel OneTweetViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<OneTweetViewViewModel>();
            }
        }
        public TweetsViewViewModel TweetsViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<TweetsViewViewModel>();
            }
        }
    }
}

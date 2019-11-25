﻿using Prism;
using Prism.Ioc;
using MyTips.Prism.ViewModels;
using MyTips.Prism.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyTips.Common.Services;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MyTips.Prism
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/TipsPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IApiService, ApiService>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<TipsPage, TipsPageViewModel>();
        }
    }
}
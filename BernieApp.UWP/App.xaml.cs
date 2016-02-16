using System;
using Windows.UI.Xaml;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Autofac;
using BernieApp.Common.DependencyInjection;
using Template10.Common;
using BernieApp.UWP.View;
using GalaViews = GalaSoft.MvvmLight.Views;
using Template10NavigationService = Template10.Services.NavigationService.INavigationService;


namespace BernieApp.UWP
{
    sealed partial class App : BootStrapper
    {
        public App()
        {
            this.InitializeComponent();
        }

        // runs even if restored from state
        public override Task OnInitializeAsync(IActivatedEventArgs args)
        {
            // content may already be shell when resuming
            if ((Window.Current.Content as Shell) == null)
            {
                // setup hamburger shell
                var nav = NavigationServiceFactory(BackButton.Attach, ExistingContent.Include);
                IOC.Default = new AutofacDIService(builder => {
                   builder.RegisterInstance(nav).As<GalaViews.INavigationService>().As<Template10NavigationService>();
                });
                Window.Current.Content = new Shell(nav);
            }
            return Task.CompletedTask;
        }

        public override Task OnStartAsync(StartKind startKind, IActivatedEventArgs args)
        {
            NavigationService.Navigate(typeof(NewsPage));
            return Task.FromResult<object>(null);
        }
    }

}

using Autofac;
using BernieApp.Common.Design;
using BernieApp.Common.Http;
using BernieApp.Common.Models;
using BernieApp.Common.ViewModels;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using System;

namespace BernieApp.Common.DependencyInjection
{
    public class AutofacDIService : IDependencyInjectionService
    {
        private readonly IContainer _container;

        public AutofacDIService(Action<ContainerBuilder> additionalBuildConfigurer = null)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType(typeof(MainViewModel));
            builder.RegisterType(typeof(NewsItemViewModel));

            if (ViewModelBase.IsInDesignModeStatic)
            {
                builder.RegisterInstance(new DesignBernieHttpClient()).As<IBernieHttpClient>();
                builder.RegisterInstance(new DesignNavigationService()).As<INavigationService>();
            }
            else
            {
                builder.RegisterType<IssuesClient>().AsSelf();
                builder.RegisterType<NewsClient>().AsSelf();
                builder.RegisterType<BernieHttpClient>().As<IBernieHttpClient>();
                additionalBuildConfigurer?.Invoke(builder);
            }

            _container = builder.Build();
        } 

        public T Resolve<T>() => _container.Resolve<T>();
    }
}
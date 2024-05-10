using coursework.Views;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using model;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using Model2;

namespace coursework
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ModelModule>().AddModule<Model2Module>();
        }

    }
}

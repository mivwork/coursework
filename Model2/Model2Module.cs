using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Ioc;
using Prism.Modularity;
using Model2.Views;
using Prism.Regions;

namespace model
{
    public class Model2Module : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var provider = containerProvider.Resolve<IRegionManager>();
            provider.RegisterViewWithRegion("Main", nameof(Autorization));
            provider.RegisterViewWithRegion("Table", nameof(Table));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<Table>();
            containerRegistry.RegisterForNavigation<MainForm>();
            containerRegistry.RegisterForNavigation<Autorization>();
        }
    }
}

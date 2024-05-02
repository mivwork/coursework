using model.DataAccess;
using Prism.Ioc;
using Prism.Modularity;


namespace model
{
    public class ModelModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry
                .RegisterSingleton<MyDbContext>()
                .RegisterSingleton<AutorizationService>()
                .RegisterSingleton<ClockService>()
                ;
        }
    }
}

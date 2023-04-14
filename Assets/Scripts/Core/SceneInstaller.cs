using System.Linq;
using UI;
using UI.MainMenu;
using UI.OfferWindow;
using UnityEngine;
using Zenject;

namespace Core
{
    public class SceneInstaller : MonoInstaller
    {
        [Inject]
        private GameSettings _gameSettings;
        
        public Transform UIRoot;
        
        public override void InstallBindings()
        {
       
            // Container.BindInterfacesAndSelfTo<MainMenuView>().FromComponentInHierarchy().AsSingle();

            // Container.BindInterfacesAndSelfTo<OfferWindowView>().FromComponentInHierarchy().AsSingle();
            // Container.BindInterfacesAndSelfTo<OfferWindowInputAdapter>().FromComponentInHierarchy().AsSingle();
            // Container.BindInterfacesAndSelfTo<OfferWindowModel>().AsSingle().NonLazy();
            // Container.BindInterfacesAndSelfTo<OfferWindowController>().AsSingle().NonLazy();
            // Container.BindInterfacesAndSelfTo<OfferWindowController>().WhenInjectedInto<OfferWindowInputAdapter>().Lazy();
            // Container.Bind<OfferWindowController>().WithId(WindowId.OfferWindow).AsTransient();
            // Container.BindFactory<IWindowData, IWindowModel, PlaceholderFactory<IWindowData, IWindowModel>>()
            //     .WithId(WindowId.OfferWindow.ToString()).FromFactory<OfferWindowModel.Factory>();
            Container.BindInterfacesAndSelfTo<UIService>().AsSingle().NonLazy();
            // Container.BindIFactory<CustomWindowFactory>().AsSingle().NonLazy();
            Container.BindFactory<IWindowData, IWindow, WindowFactory>().FromFactory<CustomWindowFactory>();

            Container.BindFactory<IWindowData, IWindowModel, WindowModelFactory>().WithId(WindowId.OfferWindow).To<OfferWindowModel>();
            Container.BindFactory<IWindowModel, IWindowController, WindowControllerFactory>().WithId(WindowId.OfferWindow).To<OfferWindowController>();
            
            Container.BindFactory<IWindowData, IWindowModel, WindowModelFactory>().WithId(WindowId.MainWindow).To<MainWindowModel>();
            Container.BindFactory<IWindowModel, IWindowController, WindowControllerFactory>().WithId(WindowId.MainWindow).To<MainWindowController>();
            
            Container.Bind<Transform>().WithId("UIRoot").FromInstance(UIRoot).AsSingle();
            Container.Bind<ISpriteProvider<ItemId>>().To<ItemsSpriteProvider>().AsTransient();
            Container.Bind<ISpriteProvider<string>>().To<ResourcesSpriteProvider>().AsTransient();
            // Container.Bind(typeof(ISpriteProvider<>)).To(typeof(ISpriteProvider<ItemId>));
            // Container.Bind(typeof(ISpriteProvider<>)).To(typeof(ISpriteProvider<string>));

            // Container.Bind<OfferWindowView>().WithId(WindowId.OfferWindow)
            //     .FromComponentInNewPrefab(_gameSettings.Windows.First(w => w.WindowId.Equals(WindowId.OfferWindow)).WindowPrefab)
            //     // .UnderTransform(UIRoot)
            //     .AsTransient();

            // Container.BindInterfacesAndSelfTo<OfferWindowModel>().AsSingle().WhenInjectedInto<OfferWindowView>()
            //     .Lazy();
            //
            // Container.BindInterfacesAndSelfTo<OfferWindowController>().AsSingle().WhenInjectedInto<OfferWindowInputAdapter>()
            //     .Lazy();
        }

        [ContextMenu("Test")]
        public void Test()
        {
            var uiService = Container.Resolve<UIService>();
            uiService.OpenWindow(new MainWindowData
            {
                WindowId = WindowId.MainWindow
            });
        }
    }
}

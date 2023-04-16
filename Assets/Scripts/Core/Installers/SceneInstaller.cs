using UI.Core;
using UI.MainWindow;
using UI.OfferWindow;
using UnityEngine;
using Zenject;

namespace Core.Installers
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private Transform UIRoot;
        private GameSettings _gameSettings;

        public SceneInstaller(GameSettings gameSettings)
        {
            _gameSettings = gameSettings;
        }

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<UIService>().AsSingle().NonLazy();
            Container.BindFactory<IWindowData, IWindow, WindowFactory>().FromFactory<CustomWindowFactory>();

            Container.BindFactory<IWindowData, IWindowModel, WindowModelFactory>().WithId(WindowId.OfferWindow)
                .To<OfferWindowModel>();
            Container.BindFactory<IWindowModel, IWindowController, WindowControllerFactory>()
                .WithId(WindowId.OfferWindow).To<OfferWindowController>();

            Container.BindFactory<IWindowData, IWindowModel, WindowModelFactory>().WithId(WindowId.MainWindow)
                .To<MainWindowModel>();
            Container.BindFactory<IWindowModel, IWindowController, WindowControllerFactory>()
                .WithId(WindowId.MainWindow).To<MainWindowController>();

            Container.Bind<Transform>().WithId("UIRoot").FromInstance(UIRoot).AsSingle();
            Container.Bind<ISpriteProvider<ItemId>>().To<ItemsSpriteProvider>().AsTransient();
            Container.Bind<ISpriteProvider<string>>().To<ResourcesSpriteProvider>().AsTransient();
        }
    }
}
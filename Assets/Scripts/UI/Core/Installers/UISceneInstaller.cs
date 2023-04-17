using UI.Core.Services;
using UI.Core.Windows;
using UI.Windows.MainWindow;
using UI.Windows.OfferWindow;
using UnityEngine;
using Zenject;

namespace UI.Core.Installers
{
    public class UISceneInstaller : MonoInstaller
    {
        [SerializeField] private Transform _uiRoot;

        public override void InstallBindings()
        {
            BindServices();
            BindFactories();
            BindUIRoot();
        }

        private void BindServices()
        {
            Container.BindInterfacesAndSelfTo<UIService>().AsSingle().NonLazy();
        }

        private void BindFactories()
        {
            Container.BindFactory<IWindowData, IWindow, WindowFactory>().FromFactory<CustomWindowFactory>();
            Container.BindFactory<IWindowData, IWindowModel, WindowModelFactory>().WithId(WindowId.OfferWindow)
                .To<OfferWindowModel>();
            Container.BindFactory<IWindowModel, IWindowController, WindowControllerFactory>()
                .WithId(WindowId.OfferWindow).To<OfferWindowController>();
            Container.BindFactory<IWindowData, IWindowModel, WindowModelFactory>().WithId(WindowId.MainWindow)
                .To<MainWindowModel>();
            Container.BindFactory<IWindowModel, IWindowController, WindowControllerFactory>()
                .WithId(WindowId.MainWindow).To<MainWindowController>();
        }

        private void BindUIRoot() => Container.Bind<Transform>().WithId("UIRoot").FromInstance(_uiRoot).AsSingle();
    }
}
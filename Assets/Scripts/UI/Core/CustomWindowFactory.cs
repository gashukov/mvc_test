using System.Linq;
using Core;
using UI.OfferWindow;
using UnityEngine;
using Zenject;

namespace UI.Core
{
    public class CustomWindowFactory : IFactory<IWindowData, IWindow>
    {
        private readonly DiContainer _diContainer;
        private readonly GameSettings _gameSettings;
        private readonly Transform _uiRoot;

        public CustomWindowFactory(DiContainer diContainer, GameSettings gameSettings,
            [Inject(Id = "UIRoot")] Transform uiRoot)
        {
            _diContainer = diContainer;
            _gameSettings = gameSettings;
            _uiRoot = uiRoot;
        }

        public IWindow Create(IWindowData windowData)
        {
            var modelFactory = _diContainer.ResolveId<WindowModelFactory>(windowData.WindowId);
            var windowModel = modelFactory.Create(windowData);

            var controllerFactory = _diContainer.ResolveId<WindowControllerFactory>(windowData.WindowId);
            var windowController = controllerFactory.Create(windowModel);

            var windowPrefab = _gameSettings.Windows.First(w => w.WindowId.Equals(windowModel.WindowId)).WindowPrefab;
            var windowObject = _diContainer.InstantiatePrefab(windowPrefab, _uiRoot);
            windowObject.GetComponent<IWindowInputAdapter>().Construct(windowController);
            var windowView = windowObject.GetComponent<IWindow>();
            windowView.Construct(windowModel);

            return windowView;
        }
    }
}
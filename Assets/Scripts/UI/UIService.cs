using UI.OfferWindow;

namespace UI
{
    public class UIService : IUIService
    {
        private IWindow _currentWindow;
        private WindowFactory _windowFactory;

        public UIService(WindowFactory windowFactory)
        {
            _windowFactory = windowFactory;
        }

        public void OpenWindow<T>(T windowData) where T : IWindowData
        {
            //current close
            
            _currentWindow = _windowFactory.Create(windowData);
        }
    }

    public interface IUIService
    {
        public void OpenWindow<T>(T windowData) where T : IWindowData;
        
    }
}
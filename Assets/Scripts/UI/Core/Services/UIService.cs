using UI.Core.Windows;

namespace UI.Core.Services
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
            _currentWindow?.Close();
            _currentWindow = _windowFactory.Create(windowData);
        }
        
        public void OpenWindowDefault<T>() where T : IWindowData, new()
        {
            _currentWindow?.Close();
            _currentWindow = _windowFactory.Create(new T());
        }
    }
}
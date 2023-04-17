using UI.Core.Windows;

namespace UI.Core.Services
{
    public interface IUIService
    {
        public void OpenWindow<T>(T windowData) where T : IWindowData;
        public void OpenWindowDefault<T>() where T : IWindowData, new();
        
    }
}
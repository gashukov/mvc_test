using UI.OfferWindow;

namespace UI.Core
{
    public interface IUIService
    {
        public void OpenWindow<T>(T windowData) where T : IWindowData;
        public void OpenWindowDefault<T>() where T : IWindowData, new();
        
    }
}
using UI.Windows.OfferWindow;

namespace UI.Core.Windows
{
    public interface IWindow
    {
        public void Construct(IWindowModel windowModel);
        public void Close();
    }
}
using UI.OfferWindow;

namespace UI.Core
{
    public interface IWindow
    {
        public void Construct(IWindowModel windowModel);
        public void Close();
    }
}
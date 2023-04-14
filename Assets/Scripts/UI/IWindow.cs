using UI.OfferWindow;

namespace UI
{
    public interface IWindow : IView
    {

        public void Construct(IWindowModel windowModel);
    }
}
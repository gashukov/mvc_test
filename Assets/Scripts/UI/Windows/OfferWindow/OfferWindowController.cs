using UI.Core.Services;
using UI.Windows.MainWindow;

namespace UI.Windows.OfferWindow
{
    public class OfferWindowController : WindowControllerBase<OfferWindowModel>
    {
        public OfferWindowController(IUIService uiService, OfferWindowModel windowModel) : base(uiService, windowModel)
        {
        }

        public void OfferBuyClicked()
        {
            UIService.OpenWindowDefault<MainWindowData>();
        }
    }
}
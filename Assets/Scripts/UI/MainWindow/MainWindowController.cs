using UI.Core;
using UI.OfferWindow;

namespace UI.MainWindow
{
    public class MainWindowController : WindowControllerBase<MainWindowModel>
    {
        public MainWindowController(IUIService uiService, MainWindowModel windowModel) : base(uiService, windowModel)
        {
        }

        public void OnOpenOfferButtonClicked(OfferWindowData windowData)
        {
            UIService.OpenWindow(windowData);
        }
    }
}
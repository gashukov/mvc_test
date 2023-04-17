using UI.Core.Services;
using UI.Windows.OfferWindow;

namespace UI.Windows.MainWindow
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
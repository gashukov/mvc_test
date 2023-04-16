using UI.Core;
using UI.OfferWindow;

namespace UI.MainWindow
{
    public class MainWindowModel : WindowModelBase
    {
        public MainWindowModel(MainWindowData mainWindowData)
        {
            WindowId = mainWindowData.WindowId;
        }
    }
}
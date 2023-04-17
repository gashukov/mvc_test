using UI.Core.Services;
using UI.Core.Windows;

namespace UI.Windows.OfferWindow
{
    public abstract class WindowControllerBase<TModel> : IWindowController where TModel : IWindowModel
    {
        protected IUIService UIService;
        protected TModel WindowModel;

        protected WindowControllerBase(IUIService uiService, TModel windowModel)
        {
            UIService = uiService;
            WindowModel = windowModel;
        }
    }
}
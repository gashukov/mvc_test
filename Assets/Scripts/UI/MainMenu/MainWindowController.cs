using UI.OfferWindow;
using UnityEngine;

namespace UI.MainMenu
{
    public class MainWindowController : WindowControllerBase<MainWindowModel>
    {
        private readonly IUIService _uiService;

        public MainWindowController(IUIService uiService, MainWindowModel mainWindowModel)
        {
            WindowModel = mainWindowModel;
            _uiService = uiService;
        }

        public void OnOpenOfferButtonClicked(OfferWindowData windowData)
        {
            Debug.Log($"[MVC][{GetType().Name}] Open offer window");

            _uiService.OpenWindow(windowData);
        }
    }
}
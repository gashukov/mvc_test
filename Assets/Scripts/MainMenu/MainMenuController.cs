using UniRx;
using UnityEngine;

namespace MainMenu
{
    public class MainMenuController : IMainMenuController
    {
        private readonly IMainMenuModel _mainMenuModel;

        public MainMenuController(IMainMenuModel mainMenuModel)
        {
            _mainMenuModel = mainMenuModel;
        }

        public void OnOpenOfferButtonClicked()
        {
            Debug.Log($"[MVC][{GetType().Name}] Open offer window");
        }
    }
}
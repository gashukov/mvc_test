using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu
{
    public class MainMenuInputAdapter : MonoBehaviour
    {
        [SerializeField] private Button _openOfferWindowButton;
        private readonly IMainMenuController _mainMenuController;
        private readonly CompositeDisposable _disposable = new CompositeDisposable();

        public MainMenuInputAdapter(IMainMenuController mainMenuController)
        {
            _mainMenuController = mainMenuController;
            _openOfferWindowButton.OnClickAsObservable().Subscribe(_ => _mainMenuController.OnOpenOfferButtonClicked()).AddTo(_disposable);
        
        }
    }
}
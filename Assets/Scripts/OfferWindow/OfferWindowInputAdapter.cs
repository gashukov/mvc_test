using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace OfferWindow
{
    public class OfferWindowInputAdapter : MonoBehaviour
    {
        [SerializeField] private Button _buyButton;
        private readonly IOfferWindowController _offerWindowController;
        private readonly CompositeDisposable _disposable = new CompositeDisposable();

        public OfferWindowInputAdapter(IOfferWindowController offerWindowController)
        {
            _offerWindowController = offerWindowController;

            _buyButton.OnClickAsObservable().Subscribe(_ => _offerWindowController.OfferBuyClicked())
                .AddTo(_disposable);
        }
    }
}
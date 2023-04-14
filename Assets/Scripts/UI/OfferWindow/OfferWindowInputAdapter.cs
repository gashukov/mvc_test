using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UI.OfferWindow
{
    public class OfferWindowInputAdapter : WindowInputAdapterBase<OfferWindowController>
    {
        [SerializeField] private Button _buyButton;
        private readonly CompositeDisposable _disposable = new CompositeDisposable();

        protected override void ConstructInner()
        {
            _buyButton.OnClickAsObservable().Subscribe(_ => WindowController.OfferBuyClicked())
                .AddTo(_disposable);
        }

    }
}
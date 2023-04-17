using UI.Core.Windows;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Windows.OfferWindow
{
    public class OfferWindowInputAdapter : WindowInputAdapterBase<OfferWindowController>
    {
        [SerializeField] private Button _buyButton;

        protected override void SetupValidation()
        {
            // no input to validate
        }

        protected override void SubscribeToInput()
        {
            _buyButton.OnClickAsObservable().Subscribe(_ => WindowController.OfferBuyClicked())
                .AddTo(this);
        }
    }
}
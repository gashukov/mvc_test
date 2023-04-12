using UniRx;
using UnityEngine;

namespace OfferWindow
{
    public class OfferWindowController : IOfferWindowController
    {
        private readonly IOfferWindowModel _offerWindowModel;
        private readonly CompositeDisposable _disposable = new CompositeDisposable();

        public OfferWindowController(IOfferWindowModel offerWindowModel)
        {
            _offerWindowModel = offerWindowModel;
        }

        public void OfferBuyClicked()
        {
            Debug.Log($"[MVC][{GetType().Name}] Offer buy");
        }
    }
}
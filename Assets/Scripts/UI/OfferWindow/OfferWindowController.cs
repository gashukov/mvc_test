using UniRx;
using UnityEngine;

namespace UI.OfferWindow
{
    public class OfferWindowController : WindowControllerBase<OfferWindowModel>
    {
        private readonly CompositeDisposable _disposable = new CompositeDisposable();

        public OfferWindowController(OfferWindowModel windowModel)
        {
            WindowModel = windowModel;
        }

        public void OfferBuyClicked()
        {
            Debug.Log($"[MVC][{GetType().Name}] Offer buy");
        }
    }
}
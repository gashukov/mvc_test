using UI.OfferWindow;
using UniRx;

namespace UI.Core
{
    public abstract class WindowModelBase : IWindowModel
    {
        public WindowId WindowId { get; set; }
        protected readonly CompositeDisposable Disposable = new CompositeDisposable();

        public void Dispose()
        {
            Disposable?.Dispose();
        }
    }
}
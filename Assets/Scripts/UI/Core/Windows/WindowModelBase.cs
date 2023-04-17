using UI.Windows.OfferWindow;
using UniRx;

namespace UI.Core.Windows
{
    public abstract class WindowModelBase<TWindowData> : IWindowModel where TWindowData : IWindowData
    {
        public WindowId WindowId { get; protected set; }
        protected readonly CompositeDisposable Disposable = new CompositeDisposable();

        protected WindowModelBase(TWindowData windowData)
        {
            WindowId = windowData.WindowId;
        }

        public void Dispose()
        {
            Disposable?.Dispose();
        }
    }
}
using UniRx;

namespace OfferWindow
{
    public class OfferWindowModel : IOfferWindowModel
    {
        private readonly CompositeDisposable _disposable = new CompositeDisposable();
        public StringReactiveProperty Title { get; set; }
        public StringReactiveProperty Description { get; set; }

        public OfferWindowModel()
        {
            Title = new StringReactiveProperty(string.Empty).AddTo(_disposable);
            Description = new StringReactiveProperty(string.Empty).AddTo(_disposable);
        }

    }
}
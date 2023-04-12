using UniRx;

namespace OfferWindow
{
    public interface IOfferWindowModel
    {
        public StringReactiveProperty Title { get; set; }
        public StringReactiveProperty Description { get; set; }
    }
}
using Core;
using UniRx;

namespace UI.OfferWindow
{
    public interface IWindowModel
    {
        public WindowId WindowId { get; set; }
    }
    
    public abstract class WindowModelBase : IWindowModel
    {
        public WindowId WindowId { get; set; }
    }
}
using System;
using Core;
using UI.Core;
using UniRx;

namespace UI.OfferWindow
{
    public interface IWindowModel : IDisposable
    {
        public WindowId WindowId { get; set; }
    }
}
using System;
using UI.Core.Windows;

namespace UI.Windows.OfferWindow
{
    public interface IWindowModel : IDisposable
    {
        public WindowId WindowId { get; }
    }
}
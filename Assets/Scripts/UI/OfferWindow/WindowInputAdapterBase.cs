using UnityEngine;

namespace UI.OfferWindow
{
    public abstract class WindowInputAdapterBase<TController> : MonoBehaviour, IWindowInputAdapter where TController : IWindowController
    {
        protected TController WindowController;
        protected abstract void ConstructInner();

        public void Construct(IWindowController windowController)
        {
            WindowController = (TController)windowController;
            ConstructInner();
        }
    }

    public interface IWindowInputAdapter
    {
        public void Construct(IWindowController windowController);
    }
}
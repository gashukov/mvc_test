using UnityEngine;

namespace UI.Core
{
    public abstract class WindowInputAdapterBase<TController> : MonoBehaviour, IWindowInputAdapter where TController : IWindowController
    {
        protected TController WindowController;

        public void Construct(IWindowController windowController)
        {
            WindowController = (TController)windowController;
            Initialize();
        }

        protected abstract void SetupValidation();

        protected abstract void SubscribeToInput();

        private void Initialize()
        {
            SetupValidation();
            SubscribeToInput();
        }
    }
}
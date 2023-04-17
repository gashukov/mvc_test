using UI.Windows.OfferWindow;
using UnityEngine;

namespace UI.Core.Windows
{
    public abstract class WindowViewBase<TModel> : MonoBehaviour, IWindow where TModel : IWindowModel
    {
        protected TModel WindowModel;

        public void Construct(IWindowModel windowModel)
        {
            WindowModel = (TModel)windowModel;
            Initialize();
        }

        public void Close()
        {
            Destroy(gameObject);
        }
        
        protected abstract void InitializeFields();
        protected abstract void SubscribeToModel();

        private void OnDestroy()
        {
            WindowModel?.Dispose();
        }

        private void Initialize()
        {
            InitializeFields();
            SubscribeToModel();
        }

    }
}
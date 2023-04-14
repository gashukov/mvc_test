using UnityEngine;

namespace UI.OfferWindow
{
    public abstract class WindowViewBase<TModel> : MonoBehaviour, IWindow where TModel : IWindowModel
    {
        protected TModel WindowModel;

        public void Construct(IWindowModel windowModel)
        {
            WindowModel = (TModel)windowModel;
            ConstructInner();
        }

        protected abstract void ConstructInner();
    }
}
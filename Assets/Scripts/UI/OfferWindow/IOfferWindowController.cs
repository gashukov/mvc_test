namespace UI.OfferWindow
{
    public abstract class WindowControllerBase<TModel> : IWindowController where TModel : IWindowModel
    {
        protected TModel WindowModel;
    }

    public interface IWindowController
    {
        
    }
}
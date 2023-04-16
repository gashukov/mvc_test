﻿using UI.Core;

namespace UI.OfferWindow
{
    public abstract class WindowControllerBase<TModel> : IWindowController where TModel : IWindowModel
    {
        protected IUIService UIService;
        protected TModel WindowModel;

        protected WindowControllerBase(IUIService uiService, TModel windowModel)
        {
            UIService = uiService;
            WindowModel = windowModel;
        }
    }
}
﻿using System;
using System.Collections.Generic;
using GameLogic.Data;
using UI.Core.Windows;

namespace UI.Windows.OfferWindow
{
    [Serializable]
    public class OfferWindowData : IWindowData
    {
        public WindowId WindowId { get; } = WindowId.OfferWindow;
        public string Title;
        public string Description;
        public string IconName;
        public float Price;
        public uint Sale;
        public List<ItemData> Items;
    }
}
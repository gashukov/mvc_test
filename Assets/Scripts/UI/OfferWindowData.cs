using System;
using System.Collections.Generic;
using Core;

namespace UI
{
    [Serializable]
    public class OfferWindowData : IWindowData
    {
        public WindowId WindowId { get; set; }
        public string Title;
        public string Description;
        public string IconName;
        public float Price;
        public int Sale;
        public List<ItemData> Items;
    }

    [Serializable]
    public class ItemData
    {
        public ItemId ItemId;
        public int Count;
    }
    
    public enum ItemId
    {
        Butter,
        Meat,
        Bread,
    }
    
    public class MainWindowData : IWindowData
    {
        public WindowId WindowId { get; set; }
    }

    public interface IWindowData
    {
        WindowId WindowId { get; set; }
    }
}
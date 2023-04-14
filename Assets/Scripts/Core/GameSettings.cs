using System;
using System.Collections.Generic;
using UI;
using UnityEngine;

namespace Core
{
    [Serializable]
    public class GameSettings
    {
        [Serializable]
        public class WindowSettings
        {
            public WindowId WindowId;
            public GameObject WindowPrefab;
        }
        [Serializable]
        public class ItemSettings
        {
            public ItemId ItemId;
            public string SpriteName;
        }
        public List<WindowSettings> Windows;
        public List<ItemSettings> Items;
        
    }
}
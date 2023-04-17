using System;
using System.Collections.Generic;
using GameLogic.Data;

namespace GameLogic.Settings
{
    [Serializable]
    public class GameSettings
    {
        [Serializable]
        public class ItemSettings
        {
            public ItemId ItemId;
            public string SpriteName;
        }

        public List<ItemSettings> Items;
    }
}
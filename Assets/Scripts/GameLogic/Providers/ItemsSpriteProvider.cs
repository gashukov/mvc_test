using System.Linq;
using GameLogic.Data;
using GameLogic.Settings;
using UnityEngine;

namespace GameLogic.Providers
{
    public class ItemsSpriteProvider : ISpriteProvider<ItemId>
    {
        private GameSettings _gameSettings;

        public ItemsSpriteProvider(GameSettings gameSettings)
        {
            _gameSettings = gameSettings;
        }

        public Sprite GetSprite(ItemId itemId)
        {
            var spriteName = _gameSettings.Items.First(item => item.ItemId.Equals(itemId)).SpriteName;
            return Resources.Load<Sprite>($"Sprites/{spriteName}");
        }
    }
}
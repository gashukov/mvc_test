using System.Linq;
using Core;
using UI.OfferWindow;
using UnityEngine;

namespace UI.Core
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
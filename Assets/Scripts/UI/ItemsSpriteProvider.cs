using System.Linq;
using Core;
using UnityEngine;

namespace UI
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
    
    public class ResourcesSpriteProvider : ISpriteProvider<string>
    {
        private GameSettings _gameSettings;
        
        public Sprite GetSprite(string name)
        {
            return Resources.Load<Sprite>($"Sprites/{name}");
        }
    }
}
using Core;
using UnityEngine;

namespace UI.Core
{
    public class ResourcesSpriteProvider : ISpriteProvider<string>
    {
        private GameSettings _gameSettings;
        
        public Sprite GetSprite(string name)
        {
            return Resources.Load<Sprite>($"Sprites/{name}");
        }
    }
}
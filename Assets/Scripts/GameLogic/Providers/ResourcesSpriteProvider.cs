using GameLogic.Settings;
using UnityEngine;

namespace GameLogic.Providers
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
using UnityEngine;

namespace GameLogic.Providers
{
    public interface ISpriteProvider<in TPath>
    {
        public Sprite GetSprite(TPath path);
    }
}
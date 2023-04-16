using UnityEngine;

namespace UI.Core
{
    public interface ISpriteProvider<in TPath>
    {
        public Sprite GetSprite(TPath path);
    }
}
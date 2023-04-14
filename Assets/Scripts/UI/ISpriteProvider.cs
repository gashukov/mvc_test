using System;
using UnityEngine;

namespace UI
{
    public interface ISpriteProvider<TPath>
    {
        public Sprite GetSprite(TPath path);
    }
    
    // public abstract class SpriteProvider<TTPath> : ISpriteProvider
    // {
    //     public Sprite GetSprite<TPath>(TPath path) where TPath : TTPath
    //     {
    //         return GetSpriteInner(path);
    //     }
    //
    //     protected abstract Sprite GetSpriteInner(TTPath path);
    // }
}
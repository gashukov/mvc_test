﻿using GameLogic.Data;
using GameLogic.Providers;
using Zenject;

namespace GameLogic.Installers
{
    public class SceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindProviders();
        }
        private void BindProviders()
        {
            Container.Bind<ISpriteProvider<ItemId>>().To<ItemsSpriteProvider>().AsSingle();
            Container.Bind<ISpriteProvider<string>>().To<ResourcesSpriteProvider>().AsSingle();
        }
    }
}
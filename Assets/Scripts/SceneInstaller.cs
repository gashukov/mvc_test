using MainMenu;
using OfferWindow;
using UniRx;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
       
        // Container.BindInterfacesAndSelfTo<MainMenuView>().FromComponentInHierarchy().AsSingle();
        Container.BindInterfacesAndSelfTo<MainMenuModel>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<MainMenuController>().AsSingle().NonLazy();
        
        // Container.BindInterfacesAndSelfTo<OfferWindowView>().FromComponentInHierarchy().AsSingle();
        // Container.BindInterfacesAndSelfTo<OfferWindowInputAdapter>().FromComponentInHierarchy().AsSingle();
        Container.BindInterfacesAndSelfTo<OfferWindowModel>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<OfferWindowController>().AsSingle().NonLazy();
    }
}

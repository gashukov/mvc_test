using GameLogic.Installers;
using UI.Core.Settings;
using UnityEngine;
using Zenject;

namespace UI.Core.Installers
{
    [CreateAssetMenu(fileName = "UISettingsInstaller", menuName = "Installers/UISettingsInstaller")]
    public class UISettingsInstaller : ScriptableObjectInstaller<SettingsInstaller>
    {
        [SerializeField]
        private UISettings _uiSettings;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<UISettings>().FromInstance(_uiSettings).AsSingle();
        }
    }
}
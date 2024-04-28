using UnityEngine;
using Zenject;

namespace Core.Upgrade
{
    [CreateAssetMenu(fileName = "UpgradeInstaller", menuName = "Installers/UpgradeInstaller")]
    public class UpgradeInstaller : ScriptableObjectInstaller<UpgradeInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IGunUpgrader>().To<GunUpgrader>().AsSingle().NonLazy();
        }
    }
}

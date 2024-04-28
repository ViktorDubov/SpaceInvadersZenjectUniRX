using UnityEngine;
using Zenject;

using Core.DataManagement.Resolver;
using Core.DataManagement.Border;

namespace Core.DataManagement
{
    [CreateAssetMenu(fileName = "DataManagementInstaller", menuName = "Installers/DataManagementInstaller")]
    public class DataManagementInstaller : ScriptableObjectInstaller<DataManagementInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IResolver>().To<ZenjectResolver>().AsSingle().NonLazy();

            Container.Bind<BorderData>().AsSingle().NonLazy();
        }
    }
}
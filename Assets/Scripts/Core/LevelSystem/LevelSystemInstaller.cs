using UnityEngine;
using Zenject;

namespace Core.LevelSystems
{
    [CreateAssetMenu(fileName = "LevelSystemInstaller", menuName = "Installers/LevelSystemInstaller")]
    public class LevelSystemInstaller : ScriptableObjectInstaller<LevelSystemInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<ILevelStarter>().To<LevelStarter>().AsSingle().NonLazy();
            Container.Bind<ILevelPauser>().To<LevelPauser>().AsSingle().NonLazy();
            Container.Bind<ILevelFinisher>().To<LevelFinisher>().AsSingle().NonLazy();
        }
    }
}

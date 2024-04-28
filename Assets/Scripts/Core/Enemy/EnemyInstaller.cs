using UnityEngine;
using Zenject;

namespace Core.Enemy
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField]
        EnemyGenerator generator;
        public override void InstallBindings()
        {
            Container.Bind<IEnemyGenerator>().FromInstance(generator).AsSingle().NonLazy();
            Container.Bind<IEnemyCounter>().To<EnemyCounter>().AsSingle().NonLazy();
        }
    }
}
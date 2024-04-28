using UnityEngine;
using Zenject;

namespace Core.Player
{
    public class PlayerPlacerInstaller : MonoInstaller
    {
        [SerializeField]
        PlayerPlacer placer;
        public override void InstallBindings()
        {
            Container.Bind<IPlayerPlacer>().FromInstance(placer).AsSingle().NonLazy();
        }
    }
}

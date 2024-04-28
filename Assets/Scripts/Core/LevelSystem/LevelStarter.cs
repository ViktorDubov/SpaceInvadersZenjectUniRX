using UnityEngine;
using Core.Player;
using Core.Enemy;
using Core.UI.PopUps;

namespace Core.LevelSystems
{
    public class LevelStarter : ILevelStarter
    {
        IPlayerPlacer playerPlacer;
        IEnemyGenerator enemyGenerator;
        IPopUpController popUpController;
        public LevelStarter(IPlayerPlacer playerPlacer,
            IEnemyGenerator enemyGenerator,
            IPopUpController popUpController)
        {
            this.playerPlacer = playerPlacer;
            this.enemyGenerator = enemyGenerator;
            this.popUpController = popUpController;
        }
        public void StartLevel()
        {
            popUpController.ShowPopUp<PauseButton>();
            popUpController.ShowPopUp<EnemyCountDisplayer>();
            playerPlacer.PlacePlayer(Vector3.zero);
            enemyGenerator.GenerateEnemy();
        }
    }
}


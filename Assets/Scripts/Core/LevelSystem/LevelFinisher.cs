using Core.Player;
using Core.Enemy;
using Core.UI.PopUps;

namespace Core.LevelSystems
{
    public class LevelFinisher : ILevelFinisher
    {
        IPlayerPlacer playerPlacer;
        IEnemyGenerator enemyGenerator;
        IPopUpController popUpController;
        public LevelFinisher(IPlayerPlacer playerPlacer,
            IEnemyGenerator enemyGenerator,
            IPopUpController popUpController)
        {
            this.playerPlacer = playerPlacer;
            this.enemyGenerator = enemyGenerator;
            this.popUpController = popUpController;
        }
       
        public void FinnishLevel(FinishReason finishReason)
        {
            popUpController.HidePopUp<PauseButton>();
            popUpController.HidePopUp<EnemyCountDisplayer>();

            switch (finishReason)
            {
                case FinishReason.Win:
                    popUpController.ShowPopUp<WinPopUp>();
                    break;
                case FinishReason.Lose:
                    popUpController.ShowPopUp<LosePoUp>();
                    break;
                case FinishReason.Break:
                    break;
                default:
                    break;
            }
            playerPlacer.DestroyPlayer();
            enemyGenerator.ClearEnemy();
        }
    }
}
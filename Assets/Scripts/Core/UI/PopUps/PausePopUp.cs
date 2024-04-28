using Zenject;
using Core.LevelSystems;

namespace Core.UI.PopUps
{
    public class PausePopUp : PopUpBase
    {
        ILevelStarter levelStarter;
        ILevelFinisher levelFinisher;
        ILevelPauser levelPauser;

        [Inject]
        public void Construct(ILevelStarter levelStarter, 
            ILevelFinisher levelFinisher,
            ILevelPauser levelPauser)
        {
            this.levelStarter = levelStarter;
            this.levelFinisher = levelFinisher;
            this.levelPauser = levelPauser;
        }

        public void ToMainMenuOnClick()
        {
            levelPauser.UnPauseLevel();
            levelFinisher.FinnishLevel(FinishReason.Break);
            HidePopUp();
            popUpController.ShowPopUp<MainMenuPopUp>();
        }
        public void RestartOnClick()
        {
            levelPauser.UnPauseLevel();
            levelFinisher.FinnishLevel(FinishReason.Break);
            levelStarter.StartLevel();
            HidePopUp();
        }
        public void ContinueOnCkick()
        {
            levelPauser.UnPauseLevel();
            HidePopUp();
        }
    }
}


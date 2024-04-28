using Zenject;
using Core.LevelSystems;

namespace Core.UI.PopUps
{
    public class LosePoUp : PopUpBase
    {
        ILevelStarter levelStarter;

        [Inject]
        public void Construct(ILevelStarter levelStarter)
        {
            this.levelStarter = levelStarter;
        }
        public void ToMainMenuOnClick()
        {
            popUpController.ShowPopUp<MainMenuPopUp>();
            HidePopUp();
        }
        public void ContinueOnClick()
        {
            levelStarter.StartLevel();
            HidePopUp();
        }
    }
}


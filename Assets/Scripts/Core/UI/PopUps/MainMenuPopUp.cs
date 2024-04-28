using Zenject;
using Core.LevelSystems;

namespace Core.UI.PopUps
{
    public class MainMenuPopUp : PopUpBase
    {
        ILevelStarter levelStarter;

        [Inject]
        public void Construct(ILevelStarter levelStarter)
        {
            this.levelStarter = levelStarter;
        }
        public void StartOnClick()
        {
            levelStarter.StartLevel();
            HidePopUp();
        }
    }
}


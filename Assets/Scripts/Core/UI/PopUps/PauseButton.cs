using Zenject;
using Core.LevelSystems;

namespace Core.UI.PopUps
{
    public class PauseButton : PopUpBase
    {
        ILevelPauser levelPauser;

        [Inject]
        public void Construct(ILevelPauser levelPauser)
        {
            this.levelPauser = levelPauser;
        }

        public void PauseOnClick()
        {
            levelPauser.PauseLevel();
            popUpController.ShowPopUp<PausePopUp>();
        }
    }
}


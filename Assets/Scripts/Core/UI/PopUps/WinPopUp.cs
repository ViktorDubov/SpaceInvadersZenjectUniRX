using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Core.LevelSystems;

namespace Core.UI.PopUps
{
    public class WinPopUp : PopUpBase
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


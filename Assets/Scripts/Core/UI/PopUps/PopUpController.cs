using UnityEngine;
using Zenject;

namespace Core.UI.PopUps
{
    public class PopUpController : MonoBehaviour, IPopUpController
    {
        [SerializeField]
        PopUpBase[] popUps;

        [Inject]
        public void Construct()
        {
            HideAllPopUp();
            ShowPopUp<MainMenuPopUp>();
        }
        public void HideAllPopUp()
        {
            foreach (var popUp in popUps)
            {
                popUp.HidePopUp();
            }
        }

        public void HidePopUp<T>() where T : PopUpBase
        {
            for (int i = 0; i < popUps.Length; i++)
            {
                if (popUps[i].GetType().Equals(typeof(T)))
                {
                    popUps[i].HidePopUp();
                    return;
                }
            }
        }

        public void ShowPopUp<T>() where T : PopUpBase
        {
            for (int i = 0; i < popUps.Length; i++)
            {
                if (popUps[i].GetType().Equals(typeof(T)))
                {
                    popUps[i].ShowPopUp();
                    return;
                }
            }
        }
    }
}


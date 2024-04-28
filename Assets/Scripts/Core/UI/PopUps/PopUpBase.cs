using UnityEngine;
using Zenject;

namespace Core.UI.PopUps
{
    public class PopUpBase : MonoBehaviour
    {
        protected IPopUpController popUpController;

        [Inject]
        public virtual void Construct(IPopUpController popUpController)
        {
            this.popUpController = popUpController;
        }

        public virtual void ShowPopUp()
        {
            this.gameObject.SetActive(true);
        }
        public virtual void HidePopUp()
        {
            this.gameObject.SetActive(false);
        }
    }
}


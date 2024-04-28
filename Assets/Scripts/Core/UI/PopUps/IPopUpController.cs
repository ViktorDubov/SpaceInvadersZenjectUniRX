namespace Core.UI.PopUps
{
    public interface IPopUpController
    {
        void ShowPopUp<T>() where T : PopUpBase;
        void HidePopUp<T>() where T : PopUpBase;
        void HideAllPopUp();
    }
}


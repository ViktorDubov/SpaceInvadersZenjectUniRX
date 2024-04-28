using UnityEngine;
using Zenject;
using Core.UI.PopUps;

namespace Core.UI
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField]
        UIInput input;
        [SerializeField]
        PopUpController popUpController;
        public override void InstallBindings()
        {
            Container.Bind<IUIInput>().FromInstance(input).AsSingle();
            Container.Bind<IPopUpController>().FromInstance(popUpController).AsSingle();
        }
    }
}

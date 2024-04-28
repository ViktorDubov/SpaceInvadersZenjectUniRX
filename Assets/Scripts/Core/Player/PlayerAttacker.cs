using System;
using UnityEngine;
using Zenject;
using UniRx;
using Core.UI;
using Core.Gun;

namespace Core.Player
{
    public class PlayerAttacker : MonoBehaviour
    {
        CompositeDisposable disposables = new CompositeDisposable();
        [SerializeField]
        bool isCanShout = true;
        [SerializeField]
        SimpleGun gun;
        [Inject]
        public void Construct(IUIInput input)
        {
            isCanShout = true;
            input.FireAction
                .Where(x => x && isCanShout)
                .Subscribe(x => 
                {
                    isCanShout = false;
                    gun.Shout();
                    Observable.Timer(TimeSpan.FromMilliseconds(500))
                    .Subscribe(_ => isCanShout = true).AddTo(disposables);
                })
                .AddTo(disposables);
        }
        private void OnDestroy()
        {
            disposables.Clear();
        }
    }
}


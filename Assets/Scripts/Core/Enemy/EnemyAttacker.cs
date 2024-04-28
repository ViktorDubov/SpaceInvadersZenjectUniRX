using System;
using UnityEngine;
using UniRx;
using Core.Gun;

namespace Core.Enemy
{
    public class EnemyAttacker : MonoBehaviour
    {
        CompositeDisposable disposables = new CompositeDisposable();
        [SerializeField]
        SimpleGun gun;
        private void Start()
        {
            Observable.Interval(TimeSpan.FromSeconds(3))
                .Subscribe(_ =>
                {
                    RaycastHit[] hitInfos = Physics.BoxCastAll(gun.Muzzle,
                        new Vector3(3f, 0.0f, 0.1f),
                        gun.MuzzleDirection,
                        Quaternion.Euler(Vector3.zero),
                        10);
                    foreach (var item in hitInfos)
                    {
                        if (item.collider.gameObject.TryGetComponent<EnemyController>(out EnemyController enemyController))
                        {
                            return;
                        }
                    }
                    gun.Shout();
                })
                .AddTo(disposables);
        }
        private void OnDestroy()
        {
            disposables.Clear();
        }
    }
}


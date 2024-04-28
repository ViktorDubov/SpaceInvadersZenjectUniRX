using UnityEngine;
using Zenject;
using Core.Upgrade;
using UniRx;

namespace Core.Gun
{
    public class SimpleGun : MonoBehaviour
    {
        [SerializeField]
        Transform muzzle;
        public Vector3 Muzzle => muzzle.position;
        [SerializeField]
        BulletPool bulletPool;
        [SerializeField]
        float gunDamage = 10;
        [SerializeField]
        float speed = 5;
        [SerializeField]
        float timeDuration = 5;

        public Vector3 MuzzleDirection { get => (muzzle.position - transform.position).normalized; }
        [Inject]
        public void Construct(IGunUpgrader gunUpgrader)
        {
            bulletPool.InitiateBulletPool(15);
            gunUpgrader.UpgradeGunData
                .Subscribe(data =>
                {
                    gunDamage = data.GunDamage;
                    speed = data.Speed;
                    timeDuration = data.TimeDuration;
                })
                .AddTo(this);
        }

        public void Shout()
        {
            Bullet bullet = bulletPool.GetBullet();

            bullet.transform.position = muzzle.position;

            bullet.Fly(gunDamage, speed * MuzzleDirection, timeDuration);
        }
    }
}


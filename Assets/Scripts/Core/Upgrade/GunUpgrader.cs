using UnityEngine;
using UniRx;

namespace Core.Upgrade
{
    [System.Serializable]
    public class GunData
    {
        public float GunDamage { get; }
        public float Speed { get; }
        public float TimeDuration { get; }
        public GunData(float gunDamage, float speed, float timeDuration)
        {
            GunDamage = gunDamage;
            Speed = speed;
            TimeDuration = timeDuration;
        }
    }
    public interface IGunUpgrader
    {
        public ReactiveProperty<GunData> UpgradeGunData { get; }

        void SetRandomUpgrade();
    }
    public class GunUpgrader : IGunUpgrader
    {
        public ReactiveProperty<GunData> UpgradeGunData { get; private set; }

        public GunUpgrader()
        {
            UpgradeGunData = new ReactiveProperty<GunData>(new GunData(10, 10, 5));
        }
        public void SetRandomUpgrade()
        {
            if (Random.Range(0, 100) < 40)
            {
                UpgradeGunData.Value = new GunData(
                    Random.Range(5, 15),
                    Random.Range(10, 20),
                    Random.Range(5, 10));
            }
        }
    }
}


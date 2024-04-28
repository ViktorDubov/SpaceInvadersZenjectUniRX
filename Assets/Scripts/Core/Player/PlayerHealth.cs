using UnityEngine;
using UniRx;
using UniRx.Triggers;
using Core.Gun;

namespace Core.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        CompositeDisposable disposables = new CompositeDisposable();
        
        [SerializeField]
        float maxHealth = 100;

        [SerializeField]
        Collider healthCollider;

        [SerializeField]
        public ReactiveProperty<float> HealthRP { get; private set; }

        public void Awake()
        {
            HealthRP = new ReactiveProperty<float>(maxHealth);
        }
        private void Start()
        {
            healthCollider.OnCollisionEnterAsObservable()
                .Subscribe(collider =>
                {
                    if (collider.gameObject.TryGetComponent<Bullet>(out Bullet bullet))
                    {
                        TakeDamage(bullet.Damage);
                        bullet.Stop();
                    }
                })
                .AddTo(disposables);
        }
        private void OnDestroy()
        {
            disposables.Clear();
        }

        private void TakeDamage(float damage)
        {
            if (damage > 0)
            {
                HealthRP.Value -= damage;
            }
            else
            {
                Debug.Log("Use positive value in damage");
            }   
        }
    }
}


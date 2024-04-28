using UnityEngine;
using UniRx;

namespace Core.Gun
{
    public class Bullet : MonoBehaviour
    {
        CompositeDisposable disposables = new CompositeDisposable();
        [SerializeField]
        float damage = 10;
        public float Damage => damage;

        public void Fly(float damage, Vector3 direction, float timeDuration)
        {
            this.damage = damage;
            this.gameObject.SetActive(true);
            float currentTime = 0;
            Observable.EveryFixedUpdate()
                .Subscribe(_ =>
                {
                    transform.Translate(Time.fixedDeltaTime * direction);
                    currentTime += Time.fixedDeltaTime;
                    if (currentTime > timeDuration)
                    {
                        Stop();
                    }
                })
                .AddTo(disposables);
        }
        public void Stop()
        {
            disposables.Clear();
            this.gameObject.SetActive(false);
        }
        private void OnDisable()
        {
            disposables.Clear();
        }
    }
}


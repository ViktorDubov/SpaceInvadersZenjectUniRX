using System;
using UnityEngine;
using UniRx;
using Zenject;
using Core.DataManagement.Border;

namespace Core.Enemy
{
    public class EnemyMover : MonoBehaviour
    {
        CompositeDisposable disposables = new CompositeDisposable();
        [Inject]
        public void Construct(BorderData borderData)
        {
            float t = 1;
            Observable.Interval(TimeSpan.FromSeconds(t))
                .Subscribe(_ =>
                {
                    float currentTime = 0;
                    int x;
                    if (transform.position.x < borderData.LeftBorder)
                    {
                        x = 1;
                    }
                    else if(transform.position.x > borderData.RightBorder)
                    {
                        x = -1;
                    }
                    else
                    {
                        x = UnityEngine.Random.Range(-1, 2);
                    }
                    Observable.EveryFixedUpdate()
                    .Subscribe(_ =>
                    {
                        currentTime += Time.fixedDeltaTime;
                        if (currentTime < t)
                        {
                            if(this) transform.Translate(x * Time.fixedDeltaTime * Vector3.right);
                        }
                        else
                        {
                            disposables.Clear();
                        }
                    });
                })
                .AddTo(this);            
        }
        private void OnDestroy()
        {
            disposables.Clear();
        }
    }
}


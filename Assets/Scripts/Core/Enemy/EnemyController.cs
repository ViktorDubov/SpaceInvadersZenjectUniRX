using UnityEngine;
using Zenject;
using UniRx;
using Core.Upgrade;

namespace Core.Enemy
{
    public class EnemyController : MonoBehaviour
    {
        CompositeDisposable disposables = new CompositeDisposable();

        [SerializeField]
        EnemyMover mover;
        [SerializeField]
        EnemyAttacker attacker;
        [SerializeField]
        EnemyHealth health;

        IEnemyCounter enemyCounter;
        IGunUpgrader gunUpgrader;

        [Inject]
        public void Construct(IEnemyCounter enemyCounter, IGunUpgrader gunUpgrader)
        {
            this.enemyCounter = enemyCounter;
            this.gunUpgrader = gunUpgrader;
        }
        public void Start()
        {
            health.HealthRP
                .Where(x => x <= 0)
                .Subscribe(_ =>
                {
                    enemyCounter.DecreaseEnemyCount();
                    gunUpgrader.SetRandomUpgrade();
                    Destroy(this.gameObject);
                })
                .AddTo(disposables);
        }

        private void OnDestroy()
        {
            disposables.Clear();
        }
    }
}


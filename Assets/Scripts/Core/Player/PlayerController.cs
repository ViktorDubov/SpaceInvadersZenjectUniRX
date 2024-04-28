using UnityEngine;
using Zenject;
using UniRx;
using Core.LevelSystems;

namespace Core.Player
{
    public class PlayerController : MonoBehaviour
    {
        CompositeDisposable disposables = new CompositeDisposable();

        [SerializeField]
        PlayerMover mover;
        [SerializeField]
        PlayerAttacker attacker;
        [SerializeField]
        PlayerHealth health;

        ILevelFinisher levelFinisher;

        [Inject]
        public void Construct(ILevelFinisher levelFinisher)
        {
            this.levelFinisher = levelFinisher;
        }
        public void Start()
        {
            health.HealthRP
                .Where(x => x <= 0)
                .Subscribe(_ =>
                {
                    this.gameObject.SetActive(false);
                    levelFinisher.FinnishLevel(FinishReason.Lose);
                })
                .AddTo(disposables);
        }

        private void OnDestroy()
        {
            disposables.Clear();
        }
    }
}


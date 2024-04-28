using UnityEngine;
using Zenject;
using UniRx;
using Core.Enemy;
using TMPro;

namespace Core.UI.PopUps
{
    public class EnemyCountDisplayer : PopUpBase
    {
        [SerializeField]
        TextMeshProUGUI text;
        [Inject]
        public void Construct(IEnemyCounter enemyCounter)
        {
            enemyCounter.DestroyEnemyCount
                .Subscribe(x => text.text = x.ToString())
                .AddTo(this);
        }
    }
}


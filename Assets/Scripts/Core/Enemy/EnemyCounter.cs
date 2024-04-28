using UniRx;
using Core.LevelSystems;

namespace Core.Enemy
{
    public interface IEnemyCounter
    {
        public ReactiveProperty<int> DestroyEnemyCount { get; }
        void SetEnemyCountOnLevel(int count);
        void DecreaseEnemyCount();
    }
    public class EnemyCounter : IEnemyCounter
    {
        int currentCount;

        public ReactiveProperty<int> DestroyEnemyCount { get; private set; }

        ILevelFinisher levelFinisher;

        public EnemyCounter(ILevelFinisher levelFinisher)
        {
            this.levelFinisher = levelFinisher;
            DestroyEnemyCount = new ReactiveProperty<int>(0);
        }
        public void DecreaseEnemyCount()
        {
            currentCount--;
            DestroyEnemyCount.Value++;
            if (currentCount <= 0)
            {
                levelFinisher.FinnishLevel(FinishReason.Win);
            }
        }

        public void SetEnemyCountOnLevel(int count)
        {
            currentCount = count;
            DestroyEnemyCount.Value = 0;
        }
    }
}


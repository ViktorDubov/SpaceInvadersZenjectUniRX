using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Zenject;

using Core.DataManagement.Resolver;

namespace Core.Enemy
{
    public interface IEnemyGenerator
    {
        void GenerateEnemy();
        void ClearEnemy();
    }
    public class EnemyGenerator : MonoBehaviour, IEnemyGenerator
    {
        [SerializeField]
        List<GameObject> enemies;
        [SerializeField]
        GameObject enemyPrefab;

        IResolver resolver;
        IEnemyCounter enemyCounter;
        [Inject]
        public void Construct(IResolver resolver, IEnemyCounter enemyCounter)
        {
            this.resolver = resolver;
            this.enemyCounter = enemyCounter;
            enemies = new List<GameObject>();
        }

        public void ClearEnemy()
        {
            foreach (var item in enemies)
            {
                Destroy(item);
            }
            enemies.Clear();
        }

        public void GenerateEnemy()
        {
            Vector3 currentPosition = new Vector3(0, 4, 0);
            for (int i = 0; i < 5; i++)
            {
                GameObject go = GameObject.Instantiate(enemyPrefab, this.transform);
                go.transform.position = currentPosition;
                resolver.ResolveGameObject(go);
                currentPosition.y += 1.5f;
                currentPosition.x = Random.Range(-8, 9);
                enemies.Add(go);
            }
            enemyCounter.SetEnemyCountOnLevel(enemies.Count);
        }
    }
}


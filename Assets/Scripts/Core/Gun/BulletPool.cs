using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Gun
{
    public class BulletPool : MonoBehaviour
    {
        [SerializeField]
        List<Bullet> bullets;
        [SerializeField]
        GameObject bulletPrefab;

        public virtual void InitiateBulletPool(int startBulletCount)
        {
            if (bullets == null)
            {
                bullets = new List<Bullet>(startBulletCount);
            }
            else
            {
                foreach (var item in bullets)
                {
                    Destroy(item.gameObject);
                }
                bullets.Clear();
            }
            for (int i = 0; i < startBulletCount; i++)
            {
                GameObject go = GameObject.Instantiate(bulletPrefab);
                go.SetActive(false);
                if (go.TryGetComponent<Bullet>(out Bullet bullet))
                {
                    bullets.Add(bullet);
                }
                else
                {
                    throw new System.NullReferenceException($"There is no Bullet on {bulletPrefab}");
                }
            }
        }
        private void OnDestroy()
        {
            foreach (var item in bullets)
            {
                Destroy(item.gameObject);
            }
            bullets.Clear();
        }

        public virtual Bullet GetBullet()
        {
            Bullet bullet;
            for (int i = 0; i < bullets.Count; i++)
            {
                if (!bullets[i].gameObject.activeSelf)
                {
                    return bullets[i];
                }
            }
            GameObject go = GameObject.Instantiate(bulletPrefab);
            go.SetActive(false);
            if (go.TryGetComponent<Bullet>(out Bullet loadedBullet))
            {
                bullet = loadedBullet;
                bullets.Add(bullet);
                return bullet;
            }
            else
            {
                throw new System.NullReferenceException($"There is no PistolBullet on {bulletPrefab}");
            }
        }
    }
}


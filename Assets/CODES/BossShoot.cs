using UnityEngine;

public class BossShoot : MonoBehaviour
{
    [Header("Bullet Prefab (EnemyBullet)")]
    public GameObject enemyBulletPrefab;

    [Header("Where bullets spawn (1 firepoint is enough; 3 recommended for triple)")]
    public Transform[] firePoints;

    [Header("Timing")]
    public float shootInterval = 1.2f;

    [Header("Bullet Settings")]
    public float bulletSpeed = 8f;
    public float bulletScale = 1.0f;

    [Header("Direction (for single-shot turrets)")]
    public Vector2 shootDir = Vector2.down;

    [Header("Triple Shot (center turret)")]
    public bool tripleShot = false;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= shootInterval)
        {
            Shoot();
            timer = 0f;
        }
    }

    void Shoot()
    {
        if (enemyBulletPrefab == null) return;
        if (firePoints == null || firePoints.Length == 0) return;

        if (!tripleShot)
        {
            // Single bullet (diagonal or straight)
            SpawnOne(firePoints[0].position, shootDir);
        }
        else
        {
            // Triple straight down
            // BEST setup: have 3 firepoints (Left/Mid/Right) in the center gun
            if (firePoints.Length >= 3)
            {
                SpawnOne(firePoints[0].position, Vector2.down);
                SpawnOne(firePoints[1].position, Vector2.down);
                SpawnOne(firePoints[2].position, Vector2.down);
            }
            else
            {
                // Fallback if you only gave 1 firepoint: spawn 3 bullets with slight X offsets
                Vector3 p = firePoints[0].position;
                SpawnOne(p + new Vector3(-0.25f, 0f, 0f), Vector2.down);
                SpawnOne(p, Vector2.down);
                SpawnOne(p + new Vector3(0.25f, 0f, 0f), Vector2.down);
            }
        }
    }

    void SpawnOne(Vector3 spawnPos, Vector2 dir)
    {
        GameObject b = Instantiate(enemyBulletPrefab, spawnPos, Quaternion.identity);

        // make bullet bigger if needed
        b.transform.localScale = Vector3.one * bulletScale;

        // your BulletMove supports SetDirection, so use it
        BulletMove bm = b.GetComponent<BulletMove>();
        if (bm != null)
        {
            bm.SetDirection(dir, bulletSpeed);
        }
    }
}
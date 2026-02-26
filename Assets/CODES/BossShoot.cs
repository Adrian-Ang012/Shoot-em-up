using UnityEngine;

public class BossShoot : MonoBehaviour
{
    [Header("Bullet Prefab (EnemyBullet)")]
    public GameObject enemyBulletPrefab;

    [Header("Spawn points")]
    public Transform[] firePoints;

    [Header("Timing")]
    public float shootInterval = 1.2f;

    [Header("Bullet Settings")]
    public float bulletSpeed = 8f;
    public float bulletScale = 1.0f;

    [Header("Direction (single shot)")]
    public Vector2 shootDir = Vector2.down;

    [Header("Shot Modes")]
    public bool tripleShot = false;
    public bool fiveShot = true;

    [Header("Five Shot Spread")]
    public float spreadAngle = 40f;   

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        while (timer >= shootInterval)
        {
            Shoot();
            timer -= shootInterval;
        }
    }

    void Shoot()
    {
        if (enemyBulletPrefab == null) return;
        if (firePoints == null || firePoints.Length == 0) return;

        if (fiveShot)
        {
            ShootFive();
            return;
        }

        if (tripleShot)
        {
            ShootThree();
            return;
        }

        SpawnOne(firePoints[0].position, shootDir);
    }

    void ShootThree()
    {
        if (firePoints.Length >= 3)
        {
            SpawnOne(firePoints[0].position, Vector2.down);
            SpawnOne(firePoints[1].position, Vector2.down);
            SpawnOne(firePoints[2].position, Vector2.down);
        }
        else
        {
            Vector3 p = firePoints[0].position;
            SpawnOne(p + new Vector3(-0.25f, 0f, 0f), Vector2.down);
            SpawnOne(p, Vector2.down);
            SpawnOne(p + new Vector3(0.25f, 0f, 0f), Vector2.down);
        }
    }

    void ShootFive()
    {
        Vector3 basePos = firePoints[0].position;

        float half = spreadAngle * 0.5f;
        float step = spreadAngle / 4f;

        Vector2 d0 = Rotate(Vector2.down, -half);
        Vector2 d1 = Rotate(Vector2.down, -half + step);
        Vector2 d2 = Vector2.down;
        Vector2 d3 = Rotate(Vector2.down, -half + step * 3f);
        Vector2 d4 = Rotate(Vector2.down, half);

        if (firePoints.Length >= 5)
        {
            SpawnOne(firePoints[0].position, d0);
            SpawnOne(firePoints[1].position, d1);
            SpawnOne(firePoints[2].position, d2);
            SpawnOne(firePoints[3].position, d3);
            SpawnOne(firePoints[4].position, d4);
        }
        else
        {
            SpawnOne(basePos, d0);
            SpawnOne(basePos, d1);
            SpawnOne(basePos, d2);
            SpawnOne(basePos, d3);
            SpawnOne(basePos, d4);
        }
    }

    Vector2 Rotate(Vector2 v, float degrees)
    {
        float rad = degrees * Mathf.Deg2Rad;
        float s = Mathf.Sin(rad);
        float c = Mathf.Cos(rad);
        return new Vector2(v.x * c - v.y * s, v.x * s + v.y * c).normalized;
    }

    void SpawnOne(Vector3 spawnPos, Vector2 dir)
    {
        GameObject b = Instantiate(enemyBulletPrefab, spawnPos, Quaternion.identity);

        b.transform.localScale = Vector3.one * bulletScale;

        BulletMove bm = b.GetComponent<BulletMove>();
        if (bm != null)
        {
            bm.SetDirection(dir, bulletSpeed);
        }
    }
}
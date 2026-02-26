using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject enemyBulletPrefab;
    public Transform firePoint;
    public float fireInterval = 1.5f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= fireInterval)
        {
            Shoot();
            timer = 0f;
        }
    }

    void Shoot()
    {
        if (enemyBulletPrefab == null || firePoint == null) return;
        Instantiate(enemyBulletPrefab, firePoint.position, firePoint.rotation);
    }
}
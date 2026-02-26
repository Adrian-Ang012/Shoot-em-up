using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject enemyBulletPrefab;
    public Transform firePoint;
    public float fireInterval = 1.5f;

    private float timer;

    void Update()
    {
        // If enemy is not on screen, don't even count time
        if (!IsOnScreen())
            return;

        timer += Time.deltaTime;
        if (timer >= fireInterval)
        {
            Shoot();
            timer = 0f;
        }
    }

    void Shoot()
    {
        if (enemyBulletPrefab == null || firePoint == null)
            return;

        Instantiate(enemyBulletPrefab, firePoint.position, firePoint.rotation);
    }

    bool IsOnScreen()
    {
        if (Camera.main == null) return false;

        Vector3 vp = Camera.main.WorldToViewportPoint(transform.position);

        return vp.z > 0 && vp.x >= 0 && vp.x <= 1 && vp.y >= 0 && vp.y <= 1;
    }
}
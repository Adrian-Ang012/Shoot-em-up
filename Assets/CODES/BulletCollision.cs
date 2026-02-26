using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public GameObject bulletHitFX;
    public int damage = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Wall
        if (other.CompareTag("Wall"))
        {
            HitAndDie();
            return;
        }

        // Bullet vs bullet
        if ((CompareTag("PlayerBullet") && other.CompareTag("BulletEnemy")) ||
            (CompareTag("BulletEnemy") && other.CompareTag("PlayerBullet")))
        {
            Destroy(other.gameObject);
            HitAndDie();
            return;
        }

        // Player bullet hits enemy OR boss
        if (CompareTag("PlayerBullet"))
        {
            // normal enemies
            EnemyHealth eh = other.GetComponentInParent<EnemyHealth>();
            if (eh != null)
            {
                eh.TakeDamage(damage);
                HitAndDie();
                return;
            }

            // boss
            BossHealth bh = other.GetComponentInParent<BossHealth>();
            if (bh != null)
            {
                bh.TakeDamage(damage);
                HitAndDie();
                return;
            }
        }

        // Enemy bullet hits player
        if (CompareTag("BulletEnemy") && other.CompareTag("Player"))
        {
            PlayerHealth ph = other.GetComponentInParent<PlayerHealth>();
            if (ph != null)
                ph.TakeDamage(damage);

            HitAndDie();
            return;
        }
    }

    void HitAndDie()
    {
        if (bulletHitFX != null)
            Instantiate(bulletHitFX, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
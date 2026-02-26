using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public GameObject bulletHitFX;
    public int damage = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
    
        if (other.CompareTag("Wall"))
        {
            HitAndDie();
            return;
        }

        
        if ((CompareTag("PlayerBullet") && other.CompareTag("BulletEnemy")) ||
            (CompareTag("BulletEnemy") && other.CompareTag("PlayerBullet")))
        {
            Destroy(other.gameObject);
            HitAndDie();
            return;
        }

    
        if (CompareTag("PlayerBullet"))
        {
           
            EnemyHealth eh = other.GetComponentInParent<EnemyHealth>();
            BossHealth bh = other.GetComponentInParent<BossHealth>();

            if (eh != null)
            {
                eh.TakeDamage(damage);
                HitAndDie();
                return;
            }
            if (bh != null)
            {
                bh.TakeDamage(damage);
                HitAndDie();
                return;
            }
        }

        
        if (CompareTag("BulletEnemy") && other.CompareTag("Player"))
        {
            PlayerHealth ph = other.GetComponentInParent<PlayerHealth>();
            if (ph != null)
            {
                ph.TakeDamage(damage);
            }
            HitAndDie();
            return;
        }
    }

    void HitAndDie()
    {
        if (bulletHitFX != null)
        {
        
            Instantiate(bulletHitFX, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
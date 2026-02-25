using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public GameObject bulletHitFX;
    public int damage = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wall"))
        {
            Instantiate(bulletHitFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (other.CompareTag("EnemyBullet") || other.CompareTag("PlayerBullet"))
        {
            Instantiate(bulletHitFX, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

     
        if (other.CompareTag("Enemy"))
        {
            Instantiate(bulletHitFX, transform.position, Quaternion.identity);

            
            Destroy(gameObject);
        }

      
        if (other.CompareTag("Player"))
        {
            Instantiate(bulletHitFX, transform.position, Quaternion.identity);

            

            Destroy(gameObject);
        }
    }
}
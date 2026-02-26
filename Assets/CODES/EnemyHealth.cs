using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHP = 50;
    public int currentHP;
    public int enemyScore = 100;

    [Header("Explosion Animation")]
    public GameObject TankExplodePrefab; 

    private void OnEnable()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int dmg)
    {
        currentHP -= dmg;
        if (currentHP <= 0)
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the thing we hit is the PLAYER
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collision with Player detected!");
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Die() function called on " + gameObject.name);

        if (TankExplodePrefab != null)
        {
            Vector3 spawnPos = transform.position;
            spawnPos.z -= 1f; 

            Instantiate(TankExplodePrefab, spawnPos, Quaternion.identity);
            Debug.Log("Explosion Instantiated!");
        }
        else
        {
            Debug.LogError("NO PREFAB ASSIGNED in the TankExplodePrefab slot!");
        }

        ScoreManager sm = Object.FindFirstObjectByType<ScoreManager>();
        if (sm != null) sm.AddScore(enemyScore);

        Destroy(gameObject);
    }
}
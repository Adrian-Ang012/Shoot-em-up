using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int maxHP = 500;
    public int currentHP;
    public int bossScore = 1000;

    [Header("Explosion Settings")]
    public GameObject bossExplosionPrefab; 

    private void OnEnable()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int dmg)
    {
        currentHP -= dmg;

        if (currentHP <= 0)
        {
            currentHP = 0;

            if (bossExplosionPrefab != null)
            {
                Instantiate(bossExplosionPrefab, transform.position, Quaternion.identity);
            }

            
            ScoreManager sm = Object.FindFirstObjectByType<ScoreManager>();
            if (sm != null)
            {
                sm.AddScore(bossScore);
            }

            Destroy(transform.root.gameObject);

            
        }
    }
}
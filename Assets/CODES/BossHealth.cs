using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int maxHP = 500;
    public int currentHP;

    public int bossScore = 1000;

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

            // Add score using new Unity API
            ScoreManager sm = Object.FindFirstObjectByType<ScoreManager>();
            if (sm != null)
            {
                sm.AddScore(bossScore);
            }

            // Destroy the whole boss
            Destroy(transform.root.gameObject);
        }
    }
}
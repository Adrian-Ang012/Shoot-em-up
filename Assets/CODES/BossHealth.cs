using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int maxHP = 500;
    public int currentHP = 500;

    public int bossScore = 1000;
    public GameObject bossExplosionPrefab;

    bool invulnerable = true;

    void OnEnable()
    {
        currentHP = maxHP;
    }

    public void SetInvulnerable(bool value)
    {
        invulnerable = value;
    }

    public void TakeDamage(int dmg)
    {
        if (invulnerable) return;

        currentHP -= dmg;
        if (currentHP <= 0)
        {
            currentHP = 0;

            if (bossExplosionPrefab != null)
                Instantiate(bossExplosionPrefab, transform.position, Quaternion.identity);

            var sm = Object.FindFirstObjectByType<ScoreManager>();
            if (sm != null) sm.AddScore(bossScore);

            Destroy(gameObject);
        }
    }
}
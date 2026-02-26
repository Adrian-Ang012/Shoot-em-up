using UnityEngine;

public class PlayerEnemyContactDamage : MonoBehaviour
{
    public int damageToPlayer = 10;
    public int damageToEnemy = 5;
    public float cooldown = 0.5f;

    float timer;

    void Update()
    {
        if (timer > 0f) timer -= Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (timer > 0f) return;

        // Only react to PLAYER contact (enemy-enemy overlap does nothing)
        if (!other.CompareTag("Player")) return;

        // Damage player
        PlayerHealth ph = other.GetComponentInParent<PlayerHealth>();
        if (ph != null) ph.TakeDamage(damageToPlayer);

        // Damage this enemy
        EnemyHealth eh = GetComponent<EnemyHealth>();
        if (eh != null) eh.TakeDamage(damageToEnemy);

        timer = cooldown;
    }
}
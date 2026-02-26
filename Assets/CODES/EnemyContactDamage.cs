using UnityEngine;

public class PlayerEnemyContactDamage : MonoBehaviour
{
    [Header("Damage Settings")]
    public int damageToPlayer = 10;
    public int damageToEnemy = 50; 
    public float cooldown = 0.5f;

    private float timer;

    void Update()
    {
        if (timer > 0f) 
            timer -= Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        
        if (timer > 0f) return;

    
        if (!other.CompareTag("Player")) return;

        PlayerHealth ph = other.GetComponent<PlayerHealth>();
        if (ph == null) ph = other.GetComponentInParent<PlayerHealth>();

        if (ph != null)
        {
            ph.TakeDamage(damageToPlayer);
            timer = cooldown; 
            Debug.Log("Player hit by contact!");
        }

        
        EnemyHealth eh = GetComponent<EnemyHealth>();
        if (eh == null) eh = GetComponentInParent<EnemyHealth>();

        if (eh != null)
        {
            eh.TakeDamage(damageToEnemy);
            Debug.Log("Small/Medium Enemy took contact damage!");
        }
    }
}
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 200;
    public int currentHealth;
    public TMP_Text hpText;

    public GameObject deathExplosionFX; 
    public float explosionScale = 2f;     

    void Start()
    {
        currentHealth = maxHealth;
        UpdateUI();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth < 0)
            currentHealth = 0;

        UpdateUI();

        if (currentHealth <= 0)
            GameOver();
    }

    void UpdateUI()
    {
        if (hpText != null)
            hpText.text = currentHealth.ToString();
    }

    void GameOver()
    {
        if (deathExplosionFX != null)
        {
            GameObject fx = Instantiate(deathExplosionFX, transform.position, Quaternion.identity);
            fx.transform.localScale = Vector3.one * explosionScale;
        }

        
        Destroy(gameObject);   
    }
}
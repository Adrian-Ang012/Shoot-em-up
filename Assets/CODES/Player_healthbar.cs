using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 200;
    public int currentHealth;
    public TMP_Text hpText;

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
        Debug.Log("Game Over");
    }


}
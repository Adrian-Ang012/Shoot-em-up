using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject endGamePanel; 
    public GameObject victoryImage; 
    public GameObject loseImage;    
    public TextMeshProUGUI scoreText; 

    void Awake()
    {
        Instance = this;
    }

    public void EndGame(bool playerWon)
    {
        endGamePanel.SetActive(true);
        Time.timeScale = 0f; // Freezes the action

        if (playerWon)
        {
            victoryImage.SetActive(true);
            loseImage.SetActive(false);
        }
        else
        {
            victoryImage.SetActive(false);
            loseImage.SetActive(true);
        }

        if (ScoreManager.Instance != null)
        {
            scoreText.text = "RECORD: " + ScoreManager.Instance.scoreText.text;
        }
    }
}
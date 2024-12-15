using UnityEngine;
using UnityEngine.UI;

public class scorescript : MonoBehaviour
{
    public int score = 0; // The current score
    public Text scoreText; // Reference to the UI text element
    private void Start()
    {
        score = 0;
    }
    // Method to increment the score
    public void AddScore(int amount)
    {
        score += amount; // Increment the score by the given amount
        UpdateScoreUI(); // Update the UI
    }

    // Method to update the score text in the UI
    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}

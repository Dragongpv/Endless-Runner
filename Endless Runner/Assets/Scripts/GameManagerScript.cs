using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManagerScript : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public Button MenuButton;
    //public Player player;
    public static List<int> scores = new List<int>(); // Static list to hold scores

    private const int maxScores = 5;
    private const string scoreKeyPrefix = "HighScore";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOverText.enabled = false; // Hide the game over text at the start
        MenuButton.gameObject.SetActive(false); // Hide the menu button at the start
    }



    public void GameOver()
    {
        Debug.Log("Game Over triggered");
        gameOverText.enabled = true; // Show the game over text
        MenuButton.gameObject.SetActive(true); // Show the menu button
        Time.timeScale = 0; // Freeze the game
        TryAddNewScore(Player.playerScore); // Try to add the player's score to the leaderboard
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start scene"); // Load the main menu scene
    }



    public void TryAddNewScore(int newScore)
    {
        scores = loadScores();

        scores.Add(newScore);
        scores.Sort((a, b) => b.CompareTo(a)); // Sort scores in descending order

        for (int i = 0; i < scores.Count; i++)
        {
            PlayerPrefs.SetInt(scoreKeyPrefix + i, scores[i]); // Save the top scores
        }

        PlayerPrefs.Save();

    }

    public List<int> loadScores()
    {
        List<int> scores2 = new List<int>();

        for (int i = 0; i < maxScores; i++)
        {
            if (PlayerPrefs.HasKey(scoreKeyPrefix + i))
            {
                scores2.Add(PlayerPrefs.GetInt(scoreKeyPrefix + i));
            }
        }
        return scores2;

    }



}

using UnityEngine;
using TMPro;
using System.Collections.Generic;


public class StartMenuController : MonoBehaviour
{
    public TextMeshProUGUI HighscoresList;

    private const int maxScores = 5;
    private const string scoreKeyPrefix = "HighScore";

    private void Start()
    {
       List<int> scores = LoadScores();

       for (int i = 0; i < scores.Count && i < maxScores; i++)
       {
           HighscoresList.text += $"{i + 1}. {scores[i]}\n"; 
       }
    }

    List<int> LoadScores()
    {
        List<int> scores = new List<int>();
        for (int i = 1; i <= maxScores; i++)
        {
            string key = $"{scoreKeyPrefix}{i}";
            if (PlayerPrefs.HasKey(key))
            {
                scores.Add(PlayerPrefs.GetInt(key));
            }
            else
            {
                scores.Add(0); // Default score if not set
            }
        }
        // Sort scores in descending order
        scores.Sort((a, b) => b.CompareTo(a));
        
        return scores;
    }

    public void OnStartClick()
    {
        // Load the game scene when the start button is clicked
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

    public void OnExitClick()
    {
        // Exit the application when the exit button is clicked
        Application.Quit();

        // If running in the editor, stop playing the scene
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}

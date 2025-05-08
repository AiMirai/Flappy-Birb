using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using TMPro;
public class logicScript : MonoBehaviour
{
    public int playerScore;
    public int highScore;

    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverScreen;
    public TextMeshProUGUI gameOverScoreText;      
    public TextMeshProUGUI gameOverHighScoreText;
    public GameObject pauseButton;

    [ContextMenu("Increase Score")]
    

    void Start()
    {
        // Load and display the high score at the start of the game
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = $"High Score:\n {highScore}";
    }

    public void addScore()
    {
       
          playerScore = playerScore + 1;
        scoreText.text = playerScore.ToString();
        SaveHighScore();
    }
    public int getScore()
    {
        return playerScore;
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void gameOver()
    {
        int storedHighScore = PlayerPrefs.GetInt("HighScore", 0);
        gameOverScoreText.text = playerScore.ToString();
        gameOverHighScoreText.text = storedHighScore.ToString();

        gameOverScreen.SetActive(true);
        pauseButton.SetActive(false);

    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Start Screen"); // Replace with your scene name
    }
    private void SaveHighScore()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        if (playerScore > highScore)
        {
            PlayerPrefs.SetInt("HighScore", playerScore);
            PlayerPrefs.SetString("HighScoreDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            PlayerPrefs.Save(); // Save changes
        }
    }

}
             

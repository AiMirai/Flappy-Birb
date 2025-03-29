using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
public class logicScript : MonoBehaviour
{
    public int playerScore;
    public int highScore;
    public Text highScoreText;
    public Text scoreText;
    public GameObject gameOverScreen;
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
        gameOverScreen.SetActive(true);
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
             

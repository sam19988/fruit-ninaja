using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    [Header("score elements")]
    public int score;
    public int highScore;
    public Text scoreText;
    public Text highScoreText;


    [Header("game over elements")]
    public GameObject gameOverPanle;
    public Text GOScoreText;
    public Text GOHighScoreText;

    public void increaseScore(int points)
    {
        score += points;
        scoreText.text = score.ToString();

        if (score > highScore)
        {
            PlayerPrefs.SetInt("highScore", score);
            highScoreText.text = "Best : "+score.ToString();
        }
    }

    private void Awake()
    {
        gameOverPanle.SetActive(false);
        GetHighScore();
    }


    private void GetHighScore()
    {
        if(PlayerPrefs.HasKey("highScore"))
        highScore = PlayerPrefs.GetInt("highScore");
        highScoreText.text = "Best : " + highScore.ToString();
    }


    public void onBombHit()
    {
        Time.timeScale = 0;
        
        gameOverPanle.SetActive(true);
        GOScoreText.text = "Score :"+score.ToString();

        GOHighScoreText.text = "Best Score : " + PlayerPrefs.GetInt("highScore");
    }

    public void restartGame()
    {
        score = 0;
        gameOverPanle.SetActive(false);
        scoreText.text ="Score: "+ score.ToString();
        
        foreach(GameObject g in GameObject.FindGameObjectsWithTag("interactable"))
        {
            Destroy(g);
        }
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

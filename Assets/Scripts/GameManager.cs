using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool gameStarted;
    public int score;
    public Text scoreText;
    public Text highscoreText;

    public static int lastLevel = 0;

    private void Awake()
    {
        // highscoreText.text = "High score: " + GetHighScore().ToString();
    }

    public void LoadLastLevel()
    {
        SceneManager.LoadScene(lastLevel); 
    }

    public void QuitButton()
    {
        Application.Quit();
        print("Quit");
    }


    public void StartGame()
    {
        gameStarted = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
        }
    }

    //public void EndGame()
    //{
    //    SceneManager.LoadScene(2); //scene starten
    //}

    //public void IncreaseScore()
    //{
    //    score++;
    //    scoreText.text = "Score: " + score.ToString();

    //    if (score > GetHighScore())
    //    {
    //        PlayerPrefs.SetInt("Highscore", score);
    //        highscoreText.text = "High score: " + score.ToString();
    //    }
    //}
}

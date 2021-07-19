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
}

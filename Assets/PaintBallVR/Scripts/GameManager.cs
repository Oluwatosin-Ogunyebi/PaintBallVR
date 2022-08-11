using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Color paintColor;

    public string paintColorName;

    int playerScore;

    public TMP_Text scoreText;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + playerScore;
    }

    public int GetScore()
    {
        return playerScore;
    }

    public void AddScore()
    {
        playerScore++;
    }

    public void DeductScore()
    {
        playerScore--;
    }


    public void Restart()
    {
        SceneManager.LoadScene("PaintBallVR");
    }
}

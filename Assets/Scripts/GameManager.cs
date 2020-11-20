using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public int Lives = 3;
    [SerializeField]
    private int score;
    [SerializeField]
    private int coins;
    [SerializeField]
    private bool isGameOver = false;
    private void Awake()
    {
        // check is this is the first run and either create the PlayerPrefs o
        // or Set the UI to the existing PlayerPrefs
        if (!PlayerPrefs.HasKey("Lives"))
        {
            PlayerPrefs.SetInt("Lives", Lives);
        }
        else
        {
            Lives = PlayerPrefs.GetInt("Lives");
        }
        if (!PlayerPrefs.HasKey("score"))
        {
            PlayerPrefs.SetInt("score", score);
        }
        else
        {
            Lives = PlayerPrefs.GetInt("score");
        }
        if (!PlayerPrefs.HasKey("coins"))
        {
            PlayerPrefs.SetInt("coins", coins);
        }
        else
        {
            Lives = PlayerPrefs.GetInt("coins");
        }
        if (isGameOver||Lives<1)
        {
            Lives = 3;
            coins = 0;
            score = 0;
            isGameOver = false;
        }
    }
    public int getLives()
    {
        return this.Lives;
    }
    public int getScore()
    {
        return this.score;
    }
    public int getCoins()
    {
        return this.coins;
    }

    public void addLife()
    {
        Lives++; // add +1 to lives
        PlayerPrefs.SetInt("Lives", Lives);
    }
    public void addCoin() // add +1 to coins
    {
        coins++;
        if (coins > 99)
        {
            addLife(); // add an extra life
            coins = 0; // reset coins to zero
            PlayerPrefs.SetInt("coins", coins);
        }
    }
    public void addScore(int points)
    {
        score += points;
        PlayerPrefs.SetInt("score", score);
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
    }
    void gameOverCheck()
    {
        if (Lives < 1)
        {
            Debug.Log("The Game is Over... Restarting the Level");
            SceneManager.LoadScene("SampleScene");
            isGameOver = true;
        }
    }
    public void removeLife()
    {
        Lives--;
        gameOverCheck();
    }
}

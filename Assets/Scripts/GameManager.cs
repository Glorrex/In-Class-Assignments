using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public int Lives = 3;
    [SerializeField]
    private int score;
    [SerializeField]
    private int coins;
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
    }
    public void addCoin() // add +1 to coins
    {
        coins++;
        if (coins > 99)
        {
            addLife(); // add an extra life
            coins = 0; // reset coins to zero 
        }
    }
    public void addScore(int points)
    {
        score += points;
    }
}

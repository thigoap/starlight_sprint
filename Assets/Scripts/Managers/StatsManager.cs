using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : Singleton<StatsManager>
{
    public int coinQtty = 0;
    public int totalCoins;
    public int multiplier = 1;

    float distance;
    public float highDistance;

    int enemiesHit = 0;
    public int totalEnemiesHit;
    
    void Start()
    {
        PlayerPrefs.SetFloat("HighDistance", 0);
        PlayerPrefs.SetInt("TotalCoins", 0);
        PlayerPrefs.SetInt("TotalEnemiesHit", 0);
        
        totalCoins = PlayerPrefs.GetInt("TotalCoins");
        highDistance = PlayerPrefs.GetFloat("HighDistance");
        totalEnemiesHit = PlayerPrefs.GetInt("TotalEnemiesHit");
    }

    public void UpdateStats()
    {
        SaveHighDistance();
        UpdateTotalCoins(coinQtty);
        UpdateEnemiesHit();
        multiplier = 1;
        coinQtty = 0;
        enemiesHit = 0;
    }

    public void SaveHighDistance()
    {
        distance = Mathf.FloorToInt(GameManager.Instance.distance);
        highDistance = PlayerPrefs.GetFloat("HighDistance");
        if (distance > highDistance)
        {
            PlayerPrefs.SetFloat("HighDistance", distance);
            highDistance = distance;
        }
    }

    // public void LoadHighDistance()
    // {
    //     float highDistance = PlayerPrefs.GetFloat("HighDistance");
    //     UIManager.Instance.highDistanceDistanceText.text = highDistance + " m";
    // }

    public void GainCoin(int amount)
    {
        coinQtty += amount;
        UIManager.Instance.UpdateCoinQtty();
    }

    public void UpdateTotalCoins(int amount)
    {
        totalCoins += amount;
        PlayerPrefs.SetInt("TotalCoins", totalCoins);
    }

    public void EnemyHit()
    {
        enemiesHit++;
    }    

    public void UpdateEnemiesHit()
    {
        totalEnemiesHit += enemiesHit;    
        PlayerPrefs.SetInt("TotalEnemiesHit", totalEnemiesHit);
    }
}

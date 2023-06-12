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

    public int enemiesHit = 0;
    public int totalEnemiesHit;
    
    void Start()
    {
        // only for testing
        // PlayerPrefs.SetFloat("HighDistance", 0);
        // PlayerPrefs.SetInt("TotalCoins", 0);
        // PlayerPrefs.SetInt("TotalEnemiesHit", 0);
        // only for testing

        totalCoins = PlayerPrefs.GetInt("TotalCoins");
        highDistance = PlayerPrefs.GetFloat("HighDistance");
        totalEnemiesHit = PlayerPrefs.GetInt("TotalEnemiesHit");
    }

    public void SaveStats()
    {
        SaveHighDistance();
        SaveTotalCoins();
        SaveEnemiesHit();
        // multiplier = 1;
        // coinQtty = 0;
        // enemiesHit = 0;
    }

    public void SaveHighDistance()
    {
        distance = Mathf.FloorToInt(GameManager.Instance.distance);
        highDistance = PlayerPrefs.GetFloat("HighDistance");
        if (distance > highDistance)
        {
            PlayerPrefs.SetFloat("HighDistance", distance);
            highDistance = distance;
            GameOverMenu.Instance.ShowRecordTag();
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

    public void SaveTotalCoins()
    {
        totalCoins += coinQtty;
        PlayerPrefs.SetInt("TotalCoins", totalCoins);
    }

    public void EnemyHit()
    {
        enemiesHit++;
        UIManager.Instance.UpdateEnemiesHit();
    }    

    public void SaveEnemiesHit()
    {
        totalEnemiesHit += enemiesHit;    
        PlayerPrefs.SetInt("TotalEnemiesHit", totalEnemiesHit);
    }

    public void UpdateMultiplier()
    {
        multiplier++;
        UIManager.Instance.UpdateMultiplier();
    }
}

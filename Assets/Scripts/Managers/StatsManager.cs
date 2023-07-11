using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : Singleton<StatsManager>
{
    private PlayerSavedData MyData = new PlayerSavedData();
    
    string skinName;
    SkinController skinController;

    [Header("Coins")]
    public int coinQtty = 0;
    public int totalCoins;
    public int multiplier = 1;
    
    [Header("Diamonds")]
    public int diamondQtty = 0;
    public int totalDiamonds;
    
    [Header("Distance")]
    public float highDistance;
    float distance;
    
    [Header("Enemies")]
    public int enemiesHit = 0;
    public int totalEnemiesHit;
    
    void Start() {
        LoadPlayerData();
    }

    public void UpdateStats() {
        SaveTotalCoins();
        SaveTotalDiamonds();
        SaveHighDistance();
        SaveEnemiesHit();

        SavePlayerData();
    }

    public void SaveHighDistance() {
        distance = Mathf.FloorToInt(GameManager.Instance.distance);
        // load high distance from saved data
        if (distance > highDistance) {
            highDistance = distance;
            MyData.highDistance = highDistance;
            GameOverMenu.Instance.ShowRecordTag();
        }
    }

    public void GainCoin(int amount) {
        coinQtty += amount;
        UIManager.Instance.UpdateCoinQtty();
    }

    public void SaveTotalCoins() {
        totalCoins += coinQtty;
        MyData.totalCoins = totalCoins;
    }

    public void SaveTotalDiamonds() {
        totalDiamonds += diamondQtty;
        MyData.totalDiamonds = totalDiamonds;        
    }

    public void EnemyHit() {
        enemiesHit++;
        UIManager.Instance.UpdateEnemiesHit();
        GameManager.Instance.ResetMultiplierTimer();

        if (enemiesHit % 10 == 0) {
            diamondQtty++;
            
            skinName = GameManager.Instance.DefineSkinName();
            skinController = GameObject.Find("Player " + skinName + "(Clone)").GetComponent<SkinController>(); 
            skinController.GainDiamond();            
        }
    }    

    public void SaveEnemiesHit() {
        totalEnemiesHit += enemiesHit; 
        MyData.highDistance = highDistance;   
    }

    public void UpdateMultiplier() {
        multiplier++;
        UIManager.Instance.UpdateMultiplier();
    }

    public void SavePlayerData() {       
        SaveSystem.CurrentPlayerData.PlayerSavedData = MyData;
        SaveSystem.SavePlayerData();
    }

    public void LoadPlayerData() {
        SaveSystem.LoadPlayerData();
        MyData = SaveSystem.CurrentPlayerData.PlayerSavedData;
        totalCoins = MyData.totalCoins;
        totalDiamonds = MyData.totalDiamonds;
        highDistance = MyData.highDistance;
        totalEnemiesHit = MyData.totalEnemiesHit;
    }

    public void UpdateWithResetedData() {
        MyData.totalCoins = totalCoins;
        MyData.totalDiamonds = totalDiamonds; 
        MyData.highDistance = highDistance;
        MyData.highDistance = highDistance;
    }
}

[System.Serializable]
public struct PlayerSavedData
{
    public int totalCoins;
    public int totalDiamonds;
    public float highDistance;
    public int totalEnemiesHit;
}

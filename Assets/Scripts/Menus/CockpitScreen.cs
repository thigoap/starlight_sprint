using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CockpitScreen : Singleton<CockpitScreen>
{
    public TextMeshProUGUI totalCoinsText;
    int totalCoins;
    public TextMeshProUGUI totalDiamondsText;
    int totalDiamonds;
    public TextMeshProUGUI highDistanceText;
    float highDistance;

    void Start()
    {
        // PlayerData data = SaveSystem.LoadPlayerData();

        totalCoinsText = GameObject.Find("Coins Quantity Text").GetComponent<TextMeshProUGUI>();
        // PlayerPrefs
        // totalCoins = PlayerPrefs.GetInt("TotalCoins");
        
        // SaveSystem
        totalCoins = StatsManager.Instance.totalCoins;

        totalCoinsText.text = totalCoins.ToString();

        totalDiamondsText = GameObject.Find("Diamonds Quantity Text").GetComponent<TextMeshProUGUI>();
        // PlayerPrefs
        // totalDiamonds = PlayerPrefs.GetInt("TotalDiamonds");
        
        // SaveSystem
        totalDiamonds = StatsManager.Instance.totalDiamonds;

        totalDiamondsText.text = totalDiamonds.ToString();

        highDistanceText = GameObject.Find("High Distance Text").GetComponent<TextMeshProUGUI>();
        // PlayerPrefs
        // highDistance = PlayerPrefs.GetFloat("HighDistance");
        
        // SaveSystem
        highDistance = StatsManager.Instance.highDistance;

        highDistanceText.text = highDistance.ToString() + " m";
    }
}

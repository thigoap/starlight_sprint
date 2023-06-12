using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CockpitScreen : Singleton<CockpitScreen>
{

    public TextMeshProUGUI totalCoinsText;
    int totalCoins;
    public TextMeshProUGUI highDistanceText;
    float highDistance;

    void Start()
    {
        totalCoinsText = GameObject.Find("Coins Quantity Text").GetComponent<TextMeshProUGUI>();
        totalCoins = PlayerPrefs.GetInt("TotalCoins");
        totalCoinsText.text = totalCoins.ToString();

        highDistanceText = GameObject.Find("High Distance Text").GetComponent<TextMeshProUGUI>();
        highDistance = PlayerPrefs.GetFloat("HighDistance");
        highDistanceText.text = highDistance.ToString() + " m";

        
    }
}

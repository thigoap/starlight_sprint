using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CockpitScreen : Singleton<CockpitScreen>
{

    public TextMeshProUGUI totalCoinsText;
    int totalCoins;

    void Start()
    {
        totalCoinsText = GameObject.Find("Coins Quantity Text").GetComponent<TextMeshProUGUI>();
        totalCoins = PlayerPrefs.GetInt("TotalCoins");
        totalCoinsText.text = totalCoins.ToString();
    }
}

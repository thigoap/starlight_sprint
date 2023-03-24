using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : Singleton<UIManager>
{
    TextMeshProUGUI curDistanceDistanceText;
    TextMeshProUGUI finalDistanceDistanceText;
    TextMeshProUGUI highDistanceDistanceText;
    public TextMeshProUGUI coinsQttyText; 
 
    void Start()
    {  
    }

    void Update()
    {
        if (GameManager.Instance.isPlaying)
        {
            int distance = Mathf.FloorToInt(GameManager.Instance.distance);
            curDistanceDistanceText.text = distance + " m";
        }
    }

    public void LoadUI()
    {
        curDistanceDistanceText = GameObject.Find("Current Distance Distance Text").GetComponent<TextMeshProUGUI>();
        coinsQttyText = GameObject.Find("Coins Quantity Text").GetComponent<TextMeshProUGUI>();  
    }

    public void UpdateCoinQtty()
    {
        coinsQttyText.text = StatsManager.Instance.coinQtty.ToString();
    }

}
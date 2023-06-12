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
    public TextMeshProUGUI enemiesHitText; 

    Image multiplierSr;
    public Sprite multi2x;
    public Sprite multi3x;
    public Sprite multi4x;
    public Sprite multi5x;
 

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
        enemiesHitText = GameObject.Find("Enemies Hit Text").GetComponent<TextMeshProUGUI>();
        multiplierSr = GameObject.Find("Coins Multiplier").GetComponent<Image>(); 
        multiplierSr.enabled = false;
        var tempColor = multiplierSr.color;
        tempColor.a = 1f;
        multiplierSr.color = tempColor;
    }

    public void UpdateCoinQtty()
    {
        coinsQttyText.text = StatsManager.Instance.coinQtty.ToString();
    }
    public void UpdateEnemiesHit()
    {
        enemiesHitText.text = StatsManager.Instance.enemiesHit.ToString();
    }

    public void UpdateMultiplier()
    {
        multiplierSr.enabled = true;
        switch(StatsManager.Instance.multiplier) 
        {
        case 1:
            multiplierSr.enabled = false;
            break;
        case 2:
            multiplierSr.sprite = multi2x;
            break;
        case 3:
            multiplierSr.sprite = multi3x;
            break;
        case 4:
            multiplierSr.sprite = multi4x;
            break;
        case 5:
            multiplierSr.sprite = multi5x;
            break;
        default:
            multiplierSr.enabled = false;
            break;
        }

    }

    

}
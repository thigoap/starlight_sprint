using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;

public class GameOverMenu : Singleton<GameOverMenu>
{
    TextMeshProUGUI finalDistanceDistanceText;
    Image recordTag;

    private void Start()
    {
        gameObject.SetActive(false);      
    }

    public void GameOver()
    {
        gameObject.SetActive(true);
        finalDistanceDistanceText = GameObject.Find("Final Distance Distance Text").GetComponent<TextMeshProUGUI>();
        finalDistanceDistanceText.text = "You Ran " + Mathf.FloorToInt(GameManager.Instance.distance) + " m";
        recordTag = GameObject.Find("Record Tag").GetComponent<Image>(); 
        recordTag.enabled = false;  
    }

    public void ShowRecordTag()
    {
        recordTag.enabled = true;
    }

    public void Retry()
    {
        gameObject.SetActive(false);
        GameManager.Instance.ResetGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ToCockpit()
    {
        gameObject.SetActive(false);
        GameManager.Instance.ResetGame();
        SceneManager.LoadScene("01 Cockpit");
        AudioManager.Instance.Start();
    }
}

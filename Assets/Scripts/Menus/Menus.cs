using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{

    SceneChanger sceneChanger;

    private void Awake()
    {
        sceneChanger = GameObject.Find("SceneChanger").GetComponent<SceneChanger>();            
    }

    void Start()
    {
    }

    public void Run()
    {
        AudioManager.Instance.Stop();
        sceneChanger.ChangeScene("02 Level");
    }

    public void Quit()
    {
        QuitMenu.Instance.Quit();
    }

    public void ToCredits()
    {
        sceneChanger.ChangeScene("00 Credits");  
        // GameManager.Instance.ResetSavedData();
    }

    public void ToConfig()
    {
        sceneChanger.ChangeScene("01 Config");
    }

    public void ToCockpit()
    {
        sceneChanger.ChangeScene("01 Cockpit");
    }

    public void ToShop()
    {
        sceneChanger.ChangeScene("01 Shop");
    }

    public void ToMainMenu()
    {
        sceneChanger.ChangeScene("00 Boot");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{

    SceneChanger sceneChanger;

    public IconToggle fxIconToggle;
    public IconToggle musicIconToggle;
    
    // Text highDistanceText;

    private void Awake()
    {
        // highDistanceText = GameObject.Find("High Distance Distance Text").GetComponent<Text>();
        sceneChanger = GameObject.Find("SceneChanger").GetComponent<SceneChanger>();            
    }

    void Start()
    {
        // float highDistance = PlayerPrefs.GetFloat("HighDistance");
        // highDistanceText.text = highDistance + " m";

        // Update Game Settings UI
        musicIconToggle.ToggleIcon(AudioManager.Instance.musicEnabled);
        fxIconToggle.ToggleIcon(AudioManager.Instance.sfxEnabled);
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



    public void ToggleMusic()
    {
        AudioManager.Instance.musicEnabled = !AudioManager.Instance.musicEnabled;
        if (!AudioManager.Instance.musicEnabled)
            AudioManager.Instance.Stop();
        else
           AudioManager.Instance.Start(); 

        musicIconToggle.ToggleIcon(AudioManager.Instance.musicEnabled);
    }
    
    public void ToggleSFX()
    {
        AudioManager.Instance.sfxEnabled = !AudioManager.Instance.sfxEnabled;

        fxIconToggle.ToggleIcon(AudioManager.Instance.sfxEnabled);
    }

}

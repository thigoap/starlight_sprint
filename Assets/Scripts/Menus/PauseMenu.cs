using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : Singleton<PauseMenu>
{

    private void Start()
    {
        gameObject.SetActive(false);        
    }

    public void Pause()
    {
        Time.timeScale = 0.0f;
        gameObject.SetActive(true);
        AudioManager.Instance.Pause();
        GameManager.Instance.isPaused = true;
        GameManager.Instance.isPlaying = !GameManager.Instance.isPaused;
    }

    public void Resume()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1.0f;
        GameManager.Instance.isPaused = false;
        GameManager.Instance.isPlaying = !GameManager.Instance.isPaused;
        AudioManager.Instance.Resume();
    } 

    public void ToCockpit()
    {
        gameObject.SetActive(false);  
        // StatsManager.Instance.SaveStats();   
        GameManager.Instance.ResetGame();
        SceneManager.LoadScene("01 Cockpit");
        AudioManager.Instance.Start();
    }
}


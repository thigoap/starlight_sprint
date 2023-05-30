using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    // PlayerController playerController;
    SkinController skinController;
    KitController kitController;
    string skinName;
    string kitName;
    
    [Header("Game Status")]
    public bool gameOver = false;
    public bool isPaused = false;
    public bool isPlaying = false;

    public float distance = 0;
    public float velocity = 0f;


    private void FixedUpdate()
    {
        distance += velocity * Time.fixedDeltaTime * 0.5f;
    }


    public string DefineSkinName()
    {
        skinName = PlayerPrefs.GetString("selectedSkin");
        if (skinName == "")
        {
            PlayerPrefs.SetString("selectedSkin", "Skin Male 01");
            skinName = "Skin Male 01";
        }
        return skinName;
    }

    public string DefineKitName()
    {
        kitName = PlayerPrefs.GetString("selectedKit");
        if (kitName == "")
        {
            PlayerPrefs.SetString("selectedKit", "Kit Male 01");
            kitName = "Kit Male 01";
        }
        return kitName;
    }
    
   
    public void StartGame()
    {
        skinName = DefineSkinName();
        kitName = DefineKitName();

        UIManager.Instance.LoadUI();
        // playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        skinController = GameObject.Find("Player " + skinName + "(Clone)").GetComponent<SkinController>();
        kitController = GameObject.Find("Player " + kitName + "(Clone)").GetComponent<KitController>();
        
        // playerController.animator.SetTrigger("start");
        skinController.animator.SetTrigger("start");
        kitController.animator.SetTrigger("start");
        
        velocity = 12f;
        isPlaying = true;
    }

    public void GameOver()
    {
        isPlaying = false;
        gameOver = true;
        CameraShake.Instance.StartShaking();
        AudioManager.Instance.PlayGameOverSFX();
        GameOverMenu.Instance.GameOver();

        velocity = 0f;
        // playerController.animator.SetTrigger("stop");
        skinController.animator.SetTrigger("stop");
        kitController.animator.SetTrigger("stop");
    
        AudioManager.Instance.Stop();
        StatsManager.Instance.SaveStats();
    } 

    public void Retry()
    {
        GameOverMenu.Instance.Retry();
    }

    public void ResetGame()
    {
        AudioManager.Instance.Stop();
        velocity = 0f;
        distance = 0f;
        Time.timeScale = 1.0f;
        isPlaying = false;
        isPaused = false;
        gameOver = false;
    }

    public IEnumerator SlowVelocity()
    {
        velocity *= 0.75f;
        yield return new WaitForSeconds(1.0f);
        velocity = 12f;
    }

}

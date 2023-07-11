using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using TMPro;
using System.IO;

public class GameManager : Singleton<GameManager>
{
    SkinController skinController;
    KitController kitController;
    string skinName;
    string kitName;
    
    AudioSource SFXSource;
    
    [Header("Game Status")]
    public bool gameOver = false;
    public bool isPaused = false;
    public bool isPlaying = false;
    public bool oneTime = false;

    public float multiplierTimer = 5f;    

    public float distance = 0f;
    public int intDistance = 0;
    public float velocity = 0f;
    public float slideVelocity = 0f;
    float slowerVelocity = 0f;
    public float baseVelocity = 0f;

    private void Start()
    {
        SFXSource = GameObject.Find("SFX").GetComponent<AudioSource>();
        SFXSource.volume = 1f;
    }

    private void FixedUpdate()
    {
        distance += velocity * Time.fixedDeltaTime * 0.5f;

        // increase velociy
        intDistance = (int)distance;
        if (intDistance > 0 && intDistance < 2550 && intDistance % 100 == 0)
        {
            // IncreaseVelocity();
            if (!oneTime)
            {
                StartCoroutine(IncreaseVelocityTimer());
            }
        }

        // reset multiplier by time
        if (StatsManager.Instance.multiplier > 1 && multiplierTimer >= 0f)
        {
            multiplierTimer -= Time.fixedDeltaTime;
        }

        if (multiplierTimer < 0.01f)
        {
            StatsManager.Instance.multiplier = 0;
            StatsManager.Instance.UpdateMultiplier();
        }
    }

    public void ResetMultiplierTimer()
    {
        multiplierTimer = 5f;
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

        skinController = GameObject.Find("Player " + skinName + "(Clone)").GetComponent<SkinController>();
        kitController = GameObject.Find("Player " + kitName + "(Clone)").GetComponent<KitController>();
        
        skinController.animator.SetTrigger("start");
        kitController.animator.SetTrigger("start");
        
        velocity = 12f;
        baseVelocity = velocity;
        slideVelocity = 2 * velocity;
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
        skinController.animator.SetTrigger("stop");
        kitController.animator.SetTrigger("stop");
    
        AudioManager.Instance.Stop();
        StatsManager.Instance.UpdateStats();
    } 

    public void Retry()
    {
        GameOverMenu.Instance.Retry();
    }

    public void ResetGame()
    {
        SFXSource.volume = 1f;

        AudioManager.Instance.Stop();
        velocity = 0f;
        distance = 0;
        Time.timeScale = 1.0f;
        isPlaying = false;
        isPaused = false;
        gameOver = false;

        StatsManager.Instance.multiplier = 1;
        StatsManager.Instance.coinQtty = 0;
        StatsManager.Instance.diamondQtty = 0;
        StatsManager.Instance.enemiesHit = 0;
    }

    public IEnumerator SlowVelocity()
    {
        slowerVelocity = velocity;
        velocity = 0.75f * slowerVelocity;
        yield return new WaitForSeconds(1.0f);
        velocity = baseVelocity;
    }


    public IEnumerator IncreaseVelocityTimer()
    {
        // new code
        baseVelocity = 1.02f * baseVelocity;
        slideVelocity = 2 * baseVelocity;
        // end of new code 

        oneTime = true;
        if (skinController.isSliding)
        {
            // yield return new WaitForSeconds(1.0f);
            // Debug.Log("Waited");
            // IncreaseVelocity();

            // new code
            velocity = slideVelocity;
            // end of new code
        }
        else
        {
            // IncreaseVelocity();
            // new code
            velocity = baseVelocity;
            // end of new code
        }
        yield return new WaitForSeconds(2.0f);
        oneTime = false;
    }

    public void IncreaseVelocity()
    {
        // velocity = 1.02f * baseVelocity;
        // baseVelocity = velocity;
        // slideVelocity = 2 * velocity;
        Debug.Log("Increase velocity");
        baseVelocity = 1.02f * baseVelocity;
        velocity = baseVelocity;
        slideVelocity = 2 * velocity;
    }

    public void ResetSavedData()
    {
        StatsManager.Instance.coinQtty = 0;
        StatsManager.Instance.diamondQtty = 0;
        StatsManager.Instance.enemiesHit = 0; 
        StatsManager.Instance.totalCoins = 0;
        StatsManager.Instance.totalDiamonds = 0;
        StatsManager.Instance.totalEnemiesHit = 0; 
        StatsManager.Instance.highDistance = 0;
        StatsManager.Instance.UpdateWithResetedData();
        StatsManager.Instance.SavePlayerData();

        ShopManager.Instance.ownedMaleSkins = new int[] { 1, 1, 1, 1, 1, 1, 0, 0, 0 };
        ShopManager.Instance.ownedFemaleSkins = new int[] { 1, 1, 1, 1, 1, 1, 0, 0, 0 };
        ShopManager.Instance.ownedMaleKits = new int[] { 1, 0, 0 };
        ShopManager.Instance.ownedFemaleKits = new int[] { 1, 0, 0 };
        ShopManager.Instance.UpdateWithResetedData();
        ShopManager.Instance.SaveShopData();        


        // string fullShopPath = Application.persistentDataPath + SaveSystem.SaveDirectory + SaveSystem.ShopDataFile;
        // if (File.Exists(fullShopPath))
        // {
        //     File.Delete(fullShopPath);
        // }
        // string fullPlayerPath = Application.persistentDataPath + SaveSystem.SaveDirectory + SaveSystem.PlayerDataFile;
        // if (File.Exists(fullPlayerPath))
        // {
        //     File.Delete(fullPlayerPath);            
        // }

        PlayerPrefs.DeleteAll();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    PlayerController playerController;

    [Header("Game Status")]
    public bool gameOver = false;
    public bool isPaused = false;
    public bool isPlaying = false;

    public float distance = 0;
    public float velocity = 0f;

    private void Start()
    {    
    }

    private void Update()
    {
    }

    private void FixedUpdate()
    {
        distance += velocity * Time.fixedDeltaTime * 0.5f;
    }
   
    public void StartGame()
    {
        UIManager.Instance.LoadUI();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        playerController.animator.SetTrigger("start");
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
        playerController.animator.SetTrigger("stop");

        AudioManager.Instance.Stop();
        StatsManager.Instance.UpdateStats();
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

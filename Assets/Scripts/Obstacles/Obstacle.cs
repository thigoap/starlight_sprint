using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    PlayerHealth playerHealth;
    // [HideInInspector] public PlayerController playerController;
    [HideInInspector] public SkinController skinController;
    
    string skinName;

    void Awake()
    {
        skinName = GameManager.Instance.DefineSkinName();
        // playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
        playerHealth = GameObject.Find("Player " + skinName + "(Clone)").GetComponent<PlayerHealth>();
        // playerController = GameObject.Find("Player").GetComponent<PlayerController>();   
        skinController = GameObject.Find("Player " + skinName + "(Clone)").GetComponent<SkinController>();
    }

    public void TakeHit()
    {
        playerHealth.LoseLife(1);
        StatsManager.Instance.multiplier = 1;
        AudioManager.Instance.PlayTakeHitSFX();
        StartCoroutine(GameManager.Instance.SlowVelocity());
    }
}

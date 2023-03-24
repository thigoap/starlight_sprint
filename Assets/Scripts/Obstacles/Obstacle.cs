using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    PlayerHealth playerHealth;
    [HideInInspector] public PlayerController playerController;

    void Awake()
    {
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>(); 
    }

    public void TakeHit()
    {
        playerHealth.LoseLife(1);
        StatsManager.Instance.multiplier = 1;
        AudioManager.Instance.PlayTakeHitSFX();
        StartCoroutine(GameManager.Instance.SlowVelocity());
    }
}

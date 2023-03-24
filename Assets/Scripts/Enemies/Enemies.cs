using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public SpriteRenderer powSR;
    [HideInInspector] public Animator anim;
    [HideInInspector] public SpriteRenderer sr;
    [HideInInspector] public PlayerHealth playerHealth;
    [HideInInspector] public PlayerController playerController;
    
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        powSR.enabled = false;
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();    
    }

    public void TakeHit()
    {
        playerHealth.LoseLife(1);
        StatsManager.Instance.multiplier = 1;
        // anim.SetTrigger("enemyHit");
        AudioManager.Instance.PlayTakeHitSFX();
        StartCoroutine(GameManager.Instance.SlowVelocity());
    }

    public IEnumerator KillEnemy()
    {
        AudioManager.Instance.PlayGiveHitSFX();
        StatsManager.Instance.EnemyHit();
        StatsManager.Instance.GainCoin(StatsManager.Instance.multiplier);
        if (StatsManager.Instance.multiplier < 5)
            StatsManager.Instance.multiplier++;
        CameraShake.Instance.StartShaking();
        sr.color = new Color(1f, 0, 0, 1f);
        yield return new WaitForSeconds(0.2f);
        sr.color = new Color(1f, 1f, 1f, 1f);

        sr.enabled = false;
    }
}

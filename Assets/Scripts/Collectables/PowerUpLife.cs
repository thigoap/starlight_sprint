using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpLife : Collectable
{
    PlayerHealth playerHealth;

    void Awake()
    {
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    public override void Collect()
    {
        anim.SetTrigger("collectableTaken");
        playerHealth.GainLife(1);
        AudioManager.Instance.PlayPowerUpLifeCollectedSFX();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpLife : Collectable
{
    PlayerHealth playerHealth;

    string skinName;

    void Awake()
    {
        skinName = GameManager.Instance.DefineSkinName();
        // playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
        playerHealth = GameObject.Find("Player " + skinName + "(Clone)").GetComponent<PlayerHealth>();
    }

    public override void Collect()
    {
        anim.SetTrigger("collectableTaken");
        playerHealth.GainLife(1);
        AudioManager.Instance.PlayPowerUpLifeCollectedSFX();
    }

}

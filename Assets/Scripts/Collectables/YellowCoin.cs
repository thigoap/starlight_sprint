using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowCoin : Collectable
{

    public override void Collect()
    {
        anim.SetTrigger("collectableTaken");
        
        AudioManager.Instance.PlayCoinCollectedSFX();
        StatsManager.Instance.GainCoin(1);
    }

}

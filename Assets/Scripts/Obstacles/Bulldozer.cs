using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulldozer : Obstacle
{
    public Animator anim;

    private void OnTriggerStay2D(Collider2D collider)
    {        
        if (collider.CompareTag("Player") && !playerController.isSliding)
        {
            TakeHit();
            anim.SetTrigger("obstacleHit");
            gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        }
    }
}


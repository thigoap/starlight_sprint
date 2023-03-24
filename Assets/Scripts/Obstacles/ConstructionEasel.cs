using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionEasel : Obstacle
{
    public Animator anim;

    private void OnTriggerEnter2D(Collider2D collider)
    {        
        if (collider.CompareTag("Player"))
        {
            TakeHit();
            anim.SetTrigger("obstacleHit");
            gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        }
    }
}

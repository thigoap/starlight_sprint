using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaffolding : Obstacle
{
    private void OnTriggerEnter2D(Collider2D collider)
    {        
        if (collider.CompareTag("Player"))
        {
            TakeHit();
            gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        }
    }
}

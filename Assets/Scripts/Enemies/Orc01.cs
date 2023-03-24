using UnityEngine;
using System.Collections;

public class Orc01 : Enemy
{

    private void OnTriggerEnter2D(Collider2D collider)
    {        
        if (collider.CompareTag("Player"))
        {
            if (playerController.isSliding || !playerController.isGrounded)
            {
                StartCoroutine(KillEnemy());
                powSR.enabled = true;
            }
            else
            {
                TakeHit();
                gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            }
        }
    }

}
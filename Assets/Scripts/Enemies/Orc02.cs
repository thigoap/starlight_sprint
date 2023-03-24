using UnityEngine;
using System.Collections;

public class Orc02 : Enemy
{
    float speed = 2;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {        
        if (collider.CompareTag("Player"))
        {
            if (playerController.isSliding)
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
